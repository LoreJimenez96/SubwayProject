using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationReference : MonoBehaviour {

	GameObject player;
	bool playerInRange;
	public Text station;
	public string tag;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		tag = gameObject.tag;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInRange == true) {
			station.text = tag;
		}
		if (playerInRange == false) {
			station.text = "";
		}
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == player) {
				playerInRange = true;
			}

		}
	void OnTriggerExit (Collider other) {
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}

}
