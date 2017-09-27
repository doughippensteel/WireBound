using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent (typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ParticleSystem))]

public class Enemy : Character {


	public float moveSpeed = 3;
	public ParticleSystem spray;

	public bool moveRight = true;
	bool hitWall;

	float wallCheckRadius = 0.2f;

	public Player player;
	public LayerMask whatIsWall;
	public Transform wallCheck;

	Rigidbody2D eRig;
	Animator anim;
	BoxCollider2D bColl;


	// Use this for initialization
	protected override void Start () {
		base.Start ();

		wallCheck = transform.Find ("WallCheck");
		eRig = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
		spray = GetComponent <ParticleSystem> ();
		bColl = GetComponent<BoxCollider2D> ();
	}

	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		anim.SetBool ("Walking", true);

		hitWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
		if (hitWall) {
			moveRight = !moveRight;
		}

		if (isDead == true) {
			bColl.enabled = false;
			Spray ();
		}



	}
	void Spray(){
		spray.Play ();
	}

	protected virtual void FixedUpdate()
	{
		Patrol ();

	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			player = other.gameObject.GetComponent<Player> ();
			player.DamageHealth (attackDamage);
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			moveRight = !moveRight;
		}
	}

	protected virtual void Patrol(){

		if (moveRight) {
			transform.localScale = new Vector3 (-1, 1, 1);
			eRig.velocity = new Vector2 (moveSpeed, eRig.velocity.y);
		}else {
			transform.localScale = new Vector3 (1, 1, 1);
			eRig.velocity = new Vector2 (-moveSpeed, eRig.velocity.y);
		}
	}
}
