using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public int health = 2;
	public int attackDamage = 1;
	public bool isDead = false;

	// Use this for initialization
	protected virtual void Start () {
		
	}

	public void DamageHealth(int damage){
		health -= damage;
		if (health <= 0){
			isDead = true;
		}
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if (isDead == true)
		{
			Debug.Log ("Accessing Die" + gameObject.name);
			Die ();
		}
		
	}

	protected virtual void Die()
	{
		GameControl.KillCharacter (this);
	}
}
