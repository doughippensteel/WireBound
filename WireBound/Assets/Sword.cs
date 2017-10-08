using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
	GameControl gameControl;
	public string name = "Sword";

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			gameControl.SetWeapon (name);
			Destroy (gameObject);
		}
	}
}
