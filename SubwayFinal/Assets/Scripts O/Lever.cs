using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

	public bool playerInRange;
	GameObject player;
	Animator animator;
	public bool state;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (playerInRange == true) {
			//Show "Press P to turn on/off"
			state = animator.GetBool ("isOn");
			if(Input.GetKeyDown(KeyCode.P)&& state == false){
				print ("On");
				animator.SetBool ("isOn", true);
			}
			if(Input.GetKeyDown(KeyCode.P)&& state == true){
				print ("Off");
				animator.SetBool ("isOn", false);
			}
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject == player) {
			print ("player in range");
			playerInRange = true;

		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}

}
