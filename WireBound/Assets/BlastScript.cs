using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastScript : MonoBehaviour {
	Deftero deftero;
	Rigidbody2D rig;

	float speed = 10f;
	// Use this for initialization
	void Start () {

		deftero = GetComponentInParent<Deftero> ();
		rig = GetComponent <Rigidbody2D>();
		rig.velocity = deftero.transLeft * speed;
		transform.parent = null;
		Destroy (this.gameObject, .5f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player"){

			other.gameObject.GetComponent<Player>().DamageHealth (1);

		}
	}

}
