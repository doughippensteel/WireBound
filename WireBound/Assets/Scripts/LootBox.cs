using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : BreakableBox {
	GameControl gameControl;
	ParticleSystem part;
	int burstVal;
	bool scoreAdded = false;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();
		part = GetComponent<ParticleSystem> ();
		burstVal = Random.Range(5,15);
		scoreAdded = false;
		
	}
	
	protected override void Update ()
	{
		base.Update ();
		//part.Stop();
	}

	protected override void Destruct ()
	{
		base.Destruct ();

		part.Emit (burstVal);
	
		Debug.Log (burstVal + "," + part.particleCount);
		rig.isKinematic = true;
		AddScore();
	}
	void AddScore()
	{
		if (scoreAdded == false) {
			gameControl.AddPoints (burstVal);
			scoreAdded = true;
		}
		if (scoreAdded == true)
			return;
	}
}
