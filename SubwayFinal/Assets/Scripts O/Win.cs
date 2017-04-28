using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {

	GameObject player;
	bool playerInRange;
	public Text win;
	public float restartDelay = 5f;
	public Image screenFader;
	float restartTimer;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	// Update is called once per frame
	void Update () {
		if (playerInRange == true) {
			win.text = "YOU WON";
			restartTimer += Time.deltaTime;
			screenFader.color = new Color (107f, 200f, 220f, 250f);
			win.color = new Color (255f, 255f, 255f, 255f);

			if (restartTimer >= restartDelay) {
				Application.LoadLevel (Application.loadedLevel);
			}
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
