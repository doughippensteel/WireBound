using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deftero : Enemy {
	public GameObject blast;

	Ray2D ray;
	RaycastHit2D hit;
	Transform blastOrigin;
	public Vector2 transLeft;

	float fireRate = 3f;
	float nextShot;
	float blastRange = 10f;
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

		if (seesPlayer == true) {

			BreathFire ();
		}else if (seesPlayer == false) {
			Patrol ();
		}


	}
	protected override void Patrol ()
	{
		base.Patrol ();
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
			BreathFire ();
			Debug.Log ("Player");
		} else {
			seesPlayer = false;
		}
	}

	void BreathFire(){
		Debug.Log ("Boom");
		if (Time.time > nextShot) {
			nextShot = Time.time + fireRate;
			Instantiate (blast, blastOrigin.position, Quaternion.identity, this.transform);
		}
		RaycastHit2D hit = Physics2D.Raycast (transform.position, transLeft, sightRange);


		if (hit.collider.tag == "Player") {
			seesPlayer = true;
			//BreathFire ();
			//Debug.Log ("Player");
		} else {
			seesPlayer = false;
			Patrol ();
		};
	}
}
