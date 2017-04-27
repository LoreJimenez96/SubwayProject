using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour {
	GameObject player;
	public bool inRange;
	public float explosionTimer;
	public Text explosionEnters;
	PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		explosionTimer = 90.0f;
		explosionEnters.text = "";
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inRange == true) {
			explosionEnters.text = "ExplosionEnters";
			explosionTimer -= Time.deltaTime;
			print (explosionTimer);
			if (explosionTimer <= 0) {
				playerHealth.currentHealth = 0;
				print ("explota");
				explosionTimer -= 0;
			}
		}
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject == player) {
			inRange = true;
		}
	}
}
