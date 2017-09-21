using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public GameControl gameControl;
	public Sprite[] weaponSprites;

	SpriteRenderer weaponRend;
	Player player;
	Enemy enemy;
	DestructableObject destructable;


	int damage;
	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		damage = player.attackDamage;
		weaponRend = GetComponent<SpriteRenderer> ();
		gameControl.SetWeapon (gameControl.weapon);
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SelectWeapon (string weaponName){

		if (weaponName == ("BaseballBat"))
			{ 
			weaponRend.sprite = weaponSprites[0];
			}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			enemy = other.gameObject.GetComponent<Enemy> ();
			enemy.DamageHealth (damage);
		}
		if (other.gameObject.tag == "Destructable") {
			destructable = other.gameObject.GetComponent<DestructableObject> ();
			destructable.DamageHealth (damage);
		
		}
	}
}
