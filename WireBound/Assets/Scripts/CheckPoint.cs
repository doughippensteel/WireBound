using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
	
	public GameObject spawnPoint;

	// Use this for initialization
	void Start () {
	
		spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			spawnPoint.transform.position = this.transform.position;
			Destroy (this.gameObject);
		}
	}
}
