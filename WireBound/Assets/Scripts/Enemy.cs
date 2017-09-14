﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	public float moveSpeed = 3;
	public ParticleSystem spray;



	bool moveRight = true;
	bool hitWall;


	float wallCheckRadius = 0.2f;

	public Player player;
	public LayerMask whatIsWall;
	[SerializeField]
	Transform wallCheck;
	Rigidbody2D eRig;
	Animator anim;

	// Use this for initialization
	protected override void Start () {
		base.Start ();

		wallCheck = transform.Find ("WallCheck");
		eRig = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
		spray = GetComponent <ParticleSystem> ();
	}

	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		anim.SetBool ("Walking", true);

		hitWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
		if (hitWall) {
			moveRight = !moveRight;
		}

		if (isDead == true)
			Spray ();



	}
	void Spray(){
		spray.Play ();
	}

	void FixedUpdate()
	{
		if (moveRight) {
			transform.localScale = new Vector3 (-1, 1, 1);
			eRig.velocity = new Vector2 (moveSpeed, eRig.velocity.y);
		}else {
			transform.localScale = new Vector3 (1, 1, 1);
			eRig.velocity = new Vector2 (-moveSpeed, eRig.velocity.y);
		}
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
}