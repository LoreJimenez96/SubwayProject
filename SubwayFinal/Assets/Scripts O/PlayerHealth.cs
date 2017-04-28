using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public AudioClip deathClip;                                 // The audio clip to play when the player dies.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f); 
	public bool maskOn=false;
	public bool extin = false;
	public AudioClip collectItem;
	public GameObject gasMaskFeedback;
	public GameObject foodFeedback;
	public GameObject extinFeedback;
	public float timer=3f;
	public bool activeM;
	public bool activeF;
	public bool activeE;
	// The colour the damageImage is set to, to flash.


	Animator anim;                                              // Reference to the Animator component.
	AudioSource playerAudio;                                    // Reference to the AudioSource component.
	//FirstPersonController playerMovement;                       // Reference to the player's movement.
	bool isDead;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.


	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent <Animator> ();
		playerAudio = GetComponent <AudioSource> ();
		//playerMovement = GetComponent <FirstPersonController> ();
		// Set the initial health of the player.
		currentHealth = startingHealth;
		gasMaskFeedback.gameObject.SetActive (false);
		foodFeedback.gameObject.SetActive(false);
		extinFeedback.gameObject.SetActive(false);
	}


	void Update ()
	{
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		// Reset the damaged flag.
		damaged = false;
		if(activeM==true){
			Feedback(gasMaskFeedback,activeM);
		}

		if(activeF==true){
			print ("Food: " + activeF);
			Feedback(foodFeedback,activeF);
		}

		if(activeE==true){
			print ("Extin: " + activeE);
			Feedback(extinFeedback,activeE);
		}


	}

	public void OnTriggerEnter (Collider other){
		int mm = 30;
		if (other.gameObject.tag.Equals ("Food")) {
			foodFeedback.gameObject.SetActive(true);
			activeF = true;
			timer = 3f;
			GetComponent<AudioSource> ().PlayOneShot (collectItem);
			Destroy (other.gameObject);
			healthSlider.value += mm;
			currentHealth += mm;
			print (currentHealth);
		}
		if (other.gameObject.tag.Equals ("GasMask")) {
			maskOn = true;
			print ("mask on");
			timer = 3f;
			gasMaskFeedback.gameObject.SetActive (true);
			activeM = true;
			GetComponent<AudioSource> ().PlayOneShot (collectItem);
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag.Equals ("Ext")) {
			extin = true;
			timer = 3f;
			extinFeedback.gameObject.SetActive(true);
			activeE = true;
			GetComponent<AudioSource> ().PlayOneShot (collectItem);
			Destroy (other.gameObject);
		}
	}

	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		playerAudio.Play ();
		print (currentHealth);
	}

	public void Feedback(GameObject other, bool on)
	{
		
		if(on==true)
		{
			timer-=Time.deltaTime;
			//print ("TimerFeedback: " + timer);
			if(timer<=0){
				other.gameObject.SetActive(false);
			}
		}
	}
}