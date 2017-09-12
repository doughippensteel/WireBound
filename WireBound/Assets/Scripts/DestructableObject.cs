using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour {

	public float health = 1;
	bool isDestroyed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isDestroyed == true){
			Destruct ();
		}
		
	}

	public void DamageHealth(int damage){
		health -= damage;
		if (health <= 0) {
			isDestroyed = true;
		}
	}

	void Destruct()
	{
		Destroy (this.gameObject);
	}
}
