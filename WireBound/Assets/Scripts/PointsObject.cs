using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsObject : MonoBehaviour {
	int pointsValue = 1;

	GameControl gameControl;
	ParticleSystem pointsParticles;

	// Use this for initialization
	void Awake()
	{
		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();
		pointsParticles = GetComponent<ParticleSystem> ();
		pointsParticles.Stop();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == ("Player")) {
			pointsParticles.Play ();
			Destroy (gameObject, .25f);
			gameControl.AddPoints (pointsValue);

		}
	}
	
}
