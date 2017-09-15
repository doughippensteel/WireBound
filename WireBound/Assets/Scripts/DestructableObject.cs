using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour {

	public float health = 1;
	public bool isDestroyed = false;

	public Animator anim;

	// Use this for initialization
	public void awake (){
		anim = GetComponent<Animator> ();

	}

	protected virtual void Start () {


		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
protected virtual  void Update () {
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
	// Destroy the destructable.
	protected virtual void Destruct()
	{
		Debug.Log("Destroying" + gameObject.name);
		Destroy (this.gameObject, 1f);

	}
}
