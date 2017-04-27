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
		//USAR LAS PALANCAS DEL NIVEL 3 PARA ABRIR LA PUERTA
		if (Input.GetKeyDown(KeyCode.L)&&isOpen==false) {
			animator.SetBool ("isOpen",true);
			print ("open");

		}
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
