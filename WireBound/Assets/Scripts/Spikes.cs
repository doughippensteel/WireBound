using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	int attackDamage = 1;

	Player character;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
			character = other.gameObject.GetComponent<Player> ();
			character.DamageHealth (attackDamage);
	
		
		}

	
	}
}
