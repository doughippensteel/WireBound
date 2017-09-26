using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBehavior : MonoBehaviour {
	public GameControl gameControl;
	public GameObject shopPanel;
	public Animator shopAnim;

	public Text speed;
	public Text health;
	public Text jump;

	int speedCost = 10;
	int healthCost = 10;
	int jumpCost = 10;


	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();
		shopPanel = GameObject.FindGameObjectWithTag ("ShopPanel");
		shopAnim = GetComponentInChildren<Animator> ();

		shopPanel.SetActive (false);
		speed.text = ("Speed " + speedCost + " Points");
		health.text = ("Health " + healthCost + " Points");
		jump.text = ("Jump Power " + jumpCost + " Points");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player")
			{
			//Debug.Log ("Shop");
			if (Input.GetAxis ("Vertical") >= 1)
			{
				shopPanel.SetActive (true);
			}
		}
	}

	public void BuySpeed()
	{
		Debug.Log ("Speed Purchased");
		gameControl.StatBonus ("Speed", 2);
		speedCost = speedCost * 2;
		speed.text = ("Speed " + speedCost + " Points");

	}
}
