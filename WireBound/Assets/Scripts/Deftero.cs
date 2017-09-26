using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deftero : Enemy {

	Ray2D ray;
	RaycastHit2D hit;
	Transform blastOrigin;
	Vector2 transLeft;
	float blastRange = 10;
	float sightRange = 12f;
	bool seesPlayer = false;


	// Use this for initialization
	protected override void Start () {

		base.Start ();
		blastOrigin = transform.Find ("BlastOrigin");
		moveSpeed = 2f;

	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}
	protected override void FixedUpdate(){

		base.FixedUpdate ();

		if (moveRight) {
			
				transLeft = Vector2.right;
			}
			else {
				transLeft = Vector2.left;
			}
			//Debug.DrawRay (transform.position, -transform.right * sightRange, Color.red);
			RaycastHit2D hit = Physics2D.Raycast (transform.position, transLeft, sightRange);


		if (hit.collider.tag == "Player") {
			seesPlayer = true;
			Debug.Log ("Player");
		}
	}
}
