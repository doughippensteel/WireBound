using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

	//public	PlayerPlatformerController player;
	public PlayerCharacterController player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			player = other.gameObject.GetComponent<PlayerCharacterController> ();
			player.climbable = true;
		}
	
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			player = other.gameObject.GetComponent<PlayerCharacterController> ();
			player.climbable = false;
		}

	}
}
