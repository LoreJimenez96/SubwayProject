using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour {
	GameObject player;
	public bool inRange;
	public static float explosionTimer;
	public Text explosionEnters;
	PlayerHealth playerHealth;
	public Text expTimer;
	public bool activated;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		explosionTimer = 90.0f;
		explosionEnters.text = "";
		playerHealth = player.GetComponent <PlayerHealth> ();
		activated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (inRange == false) {
			explosionEnters.text = "";

		}
		if(activated==true){
			explosionTimer -= Time.deltaTime;
			expTimer.text = ""+explosionTimer; 
		}

		if (inRange == true) {
			explosionEnters.text = "You have 90 seconds to turn the fire off or it'll explode.";
			//print (explosionTimer);

			if (explosionTimer <= 0) {
				playerHealth.currentHealth = 0;
				print ("explota");
				explosionEnters.text = "";
				explosionTimer -= 0;
			}
		}
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject == player) {
			inRange = true;
			activated = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			inRange = false;
		}

	}
}
