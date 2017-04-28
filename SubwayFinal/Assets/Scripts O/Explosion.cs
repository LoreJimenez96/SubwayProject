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
	public bool activeE;
	public GameObject info;
	public float timer=5f;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		explosionTimer = 90.0f;
		info.gameObject.SetActive (false);
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
			info.gameObject.SetActive (true);
			activeE = true;

			if (explosionTimer <= 0) {
				playerHealth.currentHealth = 0;
				//print ("explota");
				//explosionEnters.text = "";
				explosionTimer -= 0;
			}
		}
		if (activeE == true) {
			Feedback(info,activeE);
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
