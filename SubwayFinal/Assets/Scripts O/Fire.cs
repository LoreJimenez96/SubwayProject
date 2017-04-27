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
	bool Epress = false;
	public AudioClip extin;
	public AudioSource fire;
	public Text danger;
	public GameObject explosion;
	public Text exptimer;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		fire.Pause ();
		danger.text = "";
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == player) {
			fire.Play ();
			playerInRange = true;
			danger.text = "Watch out for the fire! Get the extinguisher.";
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject == player) {
			fire.Pause ();
			playerInRange = false;
			danger.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
			if(playerInRange){
				if(playerHealth.extin){
				danger.text = "Press E to use the extinguisher.";
				if (Input.GetKeyDown(KeyCode.E)){ 
					print("EliminaFuego");
					//GetComponent<AudioSource>().Play(0); //NO SE REPRODUCE
					danger.text = "Good! Fire is off, keep looking for the exit.";
					exptimer.text = "";
						Destroy (fuegoG);
					Destroy	(explosion);
					}
				}
			}
			
		timer += Time.deltaTime; 
		if (timer >= timeBetweenAttacks && playerInRange) {
			Damage ();
		}
	}

	void Damage () {
		timer = 0f;
		if (playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
