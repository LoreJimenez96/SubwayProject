using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {

	public GameObject instructionL2;
	public GameObject gasDanger;
	public float timer=3f;
	public bool activeL2;
	public bool activeG;

	// Use this for initialization
	void Start () {
		instructionL2.gameObject.SetActive (false);
		gasDanger.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (activeL2 == true) {
			Feedback (instructionL2, activeL2);
		}

		if (activeG == true) {
			Feedback (gasDanger, activeG);
		}
	}

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals ("Station2")) {
			instructionL2.gameObject.SetActive (true);
			activeL2 = true;
			timer = 3f;
		}

		if (other.gameObject.tag.Equals ("Gas")) {
			gasDanger.gameObject.SetActive (true);
			activeG = true;
			timer = 3f;
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
