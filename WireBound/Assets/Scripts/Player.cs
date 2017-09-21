using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : Character {

	public GameControl gameControl;
	public CameraBehavior camB;
	public GameObject weapon;
	public Slider healthBar;

	public bool armed = false;


	Animator anim;

	// Use this for initialization
	protected override void Start () {
		
		//FIXME: This way of accessing UI Slider is not implicit enough, could cause confusion if additional sliders are added.
		healthBar = GameObject.FindGameObjectWithTag("HUD").GetComponentInChildren<Slider>();  	// This seems more optimal than
																								//FindObjectOfType <Slider>();
		Debug.Log (transform.position);
		anim = GetComponent<Animator>();
		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();
		camB = Camera.main.GetComponent<CameraBehavior> ();
		armed = false;
		weapon = GameObject.Find ("Weapon");
		isDead = false;
		healthBar.maxValue = gameControl.playerMaxHealth;
		health = gameControl.playerMaxHealth;
		Debug.Log (health);
		camB.SetTarget ();
	

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
	
		healthBar.value = health;


	
	}


	protected override void Die()
	{
		GameControl.KillPlayer(this);
	}


}
