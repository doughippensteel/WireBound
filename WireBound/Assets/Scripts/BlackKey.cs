using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKey : MonoBehaviour {

	GameControl gameControl;


	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();
		
	}
	

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == ("Player")) {

			gameControl.hasKey = true;
			Destroy (gameObject);
		}
	}
}
