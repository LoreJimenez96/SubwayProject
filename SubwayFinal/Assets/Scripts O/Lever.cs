﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour {

	public bool playerInRange;
	GameObject player;
	Animator animator;
	public bool state;
	public Text intruction;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		animator = GetComponent<Animator> ();
		state = animator.GetBool ("isOn");

	}
	
	// Update is called once per frame
	void Update () {
		if (playerInRange == true) {
			print (state);
			intruction.text = "Press I to turn on and O to turn off";

			if(Input.GetKeyDown(KeyCode.I)&& state==false){
				animator.SetBool ("isOn", true);
				state = true;
				print ("On");
				print (state);

			}

			if(Input.GetKeyDown(KeyCode.O)&& state==true){
				animator.SetBool ("isOn", false);
				state = false;
				print ("Off");
				print (state);

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
