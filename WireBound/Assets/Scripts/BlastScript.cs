using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastScript : MonoBehaviour {
	Deftero deftero;
	Rigidbody2D rig;

	float speed = 4f;
	// Use this for initialization
	void Start () {

		deftero = GetComponentInParent<Deftero> ();
		rig = GetComponent <Rigidbody2D>();

		transform.parent = null;
		Destroy (this.gameObject, 1f);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rig.velocity = deftero.transLeft * speed;
	}


	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player"){

			other.gameObject.GetComponent<Player>().DamageHealth (1);

		}
	}

}
