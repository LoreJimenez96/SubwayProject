using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		fire.Pause ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == player) {
			fire.Play ();
			playerInRange = true;

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
				if (Input.GetKeyDown(KeyCode.E)){ 
					print("EliminaFuego");
					//GetComponent<AudioSource>().Play(0); //NO SE REPRODUCE
						Destroy (fuegoG);
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
