using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour {

	public bool playerInRange;
	GameObject player;
	Animator animator;
	public bool state;
	public GameObject instruction;
	public bool activeI;
	public float timer=.5f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		animator = GetComponent<Animator> ();
		state = animator.GetBool ("isOn");
		instruction.gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (playerInRange == true) {
			print (state);
	
			instruction.gameObject.SetActive(true);
			activeI = true;
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

		if (activeI == true) {
			Feedback(instruction,activeI);
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject == player) {
			print ("player in range");
			playerInRange = true;
			timer = .5f;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject == player) {
			playerInRange = false;
			timer = .5f;
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
