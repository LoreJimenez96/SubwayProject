using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentDamage : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 5;

	GameObject player;
	PlayerHealth playerHealth;
	bool playerInRange;
	float timer;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();


	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == player) {
			if (playerHealth.maskOn == false) {
				playerInRange = true;
			}

		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
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
