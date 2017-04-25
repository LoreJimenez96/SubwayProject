using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

	//public AudioClip sonido;
	Inventory inventory;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Item") {
			//print (other.gameObject.tag);
			//GetComponent<AudioSource>().PlayOneShot(sonido);
			Destroy (other.gameObject);
		}
		/*if (other.gameObject.tag = "Asset") {
			inventory.AddItem
		}*/
	}
}
