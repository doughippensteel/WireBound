using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballBat : MonoBehaviour {

	public string name = "BaseballBat";
 
	GameControl gameControl;

	// Use this for initialization
	void Start () {

		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == ("Player")) {
			gameControl.SetWeapon (name);
			Destroy (gameObject);
		}
	} 
}
