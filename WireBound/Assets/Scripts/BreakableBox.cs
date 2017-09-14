using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : DestructableObject {


	public BoxCollider2D coll;
	public Rigidbody2D rig;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rig = GetComponent<Rigidbody2D> ();
		coll = GetComponent<BoxCollider2D> ();
		coll.enabled = true;
		
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}

	protected override void Destruct ()
	{
		base.Destruct ();
		anim.SetBool ("Destroyed", isDestroyed);
		rig.isKinematic = true;
		coll.enabled = false;

	}


}
