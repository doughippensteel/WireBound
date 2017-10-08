using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deftero : Enemy {
	public GameObject blast;


	Ray2D ray;
	RaycastHit2D hit;
	Transform blastOrigin;
	Transform edgeCheck; 

	public Vector2 transLeft;
	public LayerMask edges;

	float fireRate = 5f;
	float nextShot;
	float blastRange = 10f;
	float sightRange = 12f;
	float edgeCheckRadius = 0.2f;

	bool notOnEdge;
	public bool seesPlayer = false;


	// Use this for initialization
	protected override void Start () {

		base.Start ();
		edgeCheck = transform.Find ("EdgeCheck");
		blastOrigin = transform.Find ("BlastOrigin");
		moveSpeed = 2f;

	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();

		notOnEdge = Physics2D.OverlapCircle (edgeCheck.position, edgeCheckRadius, edges);

		if (!notOnEdge) {

			moveRight = !moveRight;
		}
	}
	protected override void FixedUpdate(){

		if (seesPlayer == true) {
			anim.SetBool ("Breathing", true);
			//BreathFire ();
		}else if (seesPlayer == false) {
			anim.SetBool ("Breathing", false);
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


		if (hit.collider.tag == ("Player")) {
			seesPlayer = true;
			//BreathFire ();
		//	Debug.Log ("Player");
		} else {
			seesPlayer = false;
		}
	}

	void BreathFire(){
		Debug.Log ("Boom");
		Instantiate (blast, blastOrigin.position, Quaternion.identity, this.transform);
		seesPlayer = false;
		/*if (Time.time > nextShot && seesPlayer == true) {
			nextShot = Time.time + fireRate;
			//anim.SetBool ("Breathing", true);
			Instantiate (blast, blastOrigin.position, Quaternion.identity, this.transform);
			//anim.SetBool ("Breathing", false);
		
		}*/
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
