using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public PlayerHealth playerHealth;
	public float restartDelay = 5f;
	public Image screenFader;
	public Text gameOver;

	float restartTimer;

	//void Awake()
	
	// Update is called once per frame
	void Update () {
		if (playerHealth.currentHealth <= 0) {
			restartTimer += Time.deltaTime;
			screenFader.color = new Color (107f, 200f, 220f, 250f);
			gameOver.color = new Color (255f, 255f, 255f, 255f);
		
			if (restartTimer >= restartDelay) {
				Application.LoadLevel (Application.loadedLevel);
			}
	}

}
}
