using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

	GameControl gameControl;
	Animator anim;


	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();
		anim = GetComponentInChildren<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {

			anim.SetBool ("Unlocked", gameControl.hasKey);
			StartCoroutine(gameControl.LoadShopLevel());

		}
	}
}
