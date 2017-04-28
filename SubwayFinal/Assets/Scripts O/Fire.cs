using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 5;
	public GameObject fuegoG;
	GameObject player;
	PlayerHealth playerHealth;
	bool playerInRange;
	float timer;
	bool fuego;
	//bool press = false;
	public AudioClip extin;
	public AudioSource fire;
	public GameObject danger;
	public Text itemUse;
	public GameObject explosion;
	public GameObject pressE;
	public GameObject fireOff;
	public Text exptimer;
	public bool activeF;
	public bool activeFO;

	float timerT = 3f;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		fire.Pause ();
		danger.gameObject.SetActive (false);
		pressE.gameObject.SetActive (false);
		fireOff.gameObject.SetActive (false);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == player) {
			fire.Play ();
			playerInRange = true;
			danger.gameObject.SetActive (true);
			activeF = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject == player) {
			fire.Pause ();
			playerInRange = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
			if(playerInRange){
				if(playerHealth.extin){
				pressE.gameObject.SetActive (true);
				if (Input.GetKeyDown(KeyCode.E)){ 
					print("EliminaFuego");
					pressE.gameObject.SetActive (false);
					fireOff.gameObject.SetActive (true);
					activeFO = true;
					//GetComponent<AudioSource>().Play(0); //NO SE REPRODUCE
					//danger.text = "Good! Fire is off, keep looking for the exit.";
					exptimer.text = "";
					Destroy (fuegoG);
					Destroy	(explosion);
					Destroy (pressE);
					}
				}
			}
			
		timer += Time.deltaTime; 
		if (timer >= timeBetweenAttacks && playerInRange) {
			Damage ();
		}

		if (activeF == true) {
			Feedback (danger, activeF);
		}
		if (activeFO == true) {
			Feedback (fireOff, activeFO);
		}
	}

	void Damage () {
		timer = 0f;
		if (playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage (attackDamage);
		}
	}

	public void Feedback(GameObject other, bool on)
	{

		if(on==true)
		{
			timerT-=Time.deltaTime;
			//print ("TimerFeedback: " + timer);
			if(timer<=0){
				other.gameObject.SetActive(false);
			}
		}
	}
}
