using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	public GameControl gameControl;
	public GameObject weapon;

	public bool armed = false;

	Animator anim;
	
	// Use this for initialization
	protected override void Start () {
		health = 2;
		Debug.Log (transform.position);
		anim = GetComponent<Animator>();
		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();
		armed = false;
		weapon = GameObject.Find ("Weapon");
		isDead = false;
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		if (armed == true && Input.GetButtonDown ("Fire1"))
			anim.SetBool ("Attacking", true);
		else
			anim.SetBool ("Attacking", false);

		if (health <= 0) {
			Debug.Log ("Dead");
			isDead = true;
		}
		if (gameControl.hasWeapon == true) {
			armed = true;
		}else if (gameControl.hasWeapon == false){
			armed = false;
		}
		
	}


	protected override void Die()
	{
		GameControl.KillPlayer(this);
	}


}
