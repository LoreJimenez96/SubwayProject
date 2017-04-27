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
	public Text gasText;

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
		gasText.text = "";
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
	}

	public void OnTriggerEnter (Collider other){
		int mm = 30;
		if (other.gameObject.tag.Equals ("Food")) {
			//print (gameObject.tag);
			gasText.text = "Good! Food gives you health (+15)";
			GetComponent<AudioSource> ().PlayOneShot (collectItem);
			Destroy (other.gameObject);
			healthSlider.value += mm;
			currentHealth += mm;
			print (currentHealth);
		}
		if (other.gameObject.tag.Equals ("GasMask")) {
			maskOn = true;
			print ("mask on");
			gasText.text = "Use this mask to go through gas.";
			GetComponent<AudioSource> ().PlayOneShot (collectItem);
			Destroy (other.gameObject);
		}
		if (other.gameObject.tag.Equals ("Ext")) {
			extin = true;
			gasText.text = "It'll help you to turn fire off.";
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
}