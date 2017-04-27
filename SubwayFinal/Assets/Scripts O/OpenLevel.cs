using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevel : MonoBehaviour {

	public bool code;
	public GameObject lever1;
	public GameObject lever2;
	public GameObject lever3;
	public GameObject lever4;
	public GameObject lever5;
	public bool l1;
	public bool l2;
	public bool l3;
	public bool l4;
	public bool l5;
	public bool isOpen;
	Animator animator;
	GameObject player;
	public bool enter;
	public bool exit;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
		//if(Input.GetKeyDown(KeyCode.A)){
		lever1 = GameObject.FindGameObjectWithTag("L1");
		Lever l1Lever = lever1.GetComponent<Lever> ();
		l1 = l1Lever.state;
		print ("Lever 1: "+l1);

		lever2= GameObject.FindGameObjectWithTag("L2");
		Lever l2Lever = lever2.GetComponent<Lever> ();
		l2 = l2Lever.state;
		print ("Lever 2: "+l2);

		lever3= GameObject.FindGameObjectWithTag("L3");
		Lever l3Lever = lever3.GetComponent<Lever> ();
		l3 = l3Lever.state;
		print ("Lever 3: "+l3);

		lever4= GameObject.FindGameObjectWithTag("L4");
		Lever l4Lever = lever4.GetComponent<Lever> ();
		l4 = l4Lever.state;
		print ("Lever 4: "+l4);

		lever5= GameObject.FindGameObjectWithTag("L5");
		Lever l5Lever = lever5.GetComponent<Lever> ();
		l5 = l5Lever.state;
		print ("Lever 5: "+l5);

	
			//Sacar el valor de estas booleans de cada lever
		//}
			
		//USAR LAS PALANCAS DEL NIVEL 3 PARA ABRIR LA PUERTA EN VEZ DE Input.GetKeyDown(KeyCode.L)
		if (l1 == true && l2 == false && l3 == true && l4 == true && l5 == false && isOpen == false) {
			animator.SetBool ("isOpen", true);
			print ("OPEN");
		} else {
		
			print ("AUN NO ESTA LA COMBINACION");
		}
		/*if (Input.GetKeyDown(KeyCode.L)&&isOpen==false) {
			animator.SetBool ("isOpen",true);
			print ("open");


		}*/
		if (enter==true) {
			animator.SetBool ("isOpen",false);
			print ("close");
		}


	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject == player) {
			enter = true;
		}
	}

	/*void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			exit = true;
		}
	}*/

}
