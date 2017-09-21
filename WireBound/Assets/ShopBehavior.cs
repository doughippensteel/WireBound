using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBehavior : MonoBehaviour {
	public GameControl gameControl;
	public GameObject shopPanel;
	public Animator shopAnim;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();
		shopPanel = GameObject.FindGameObjectWithTag ("ShopPanel");
		shopAnim = GetComponentInChildren<Animator> ();

		shopPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player")
			{
			Debug.Log ("Shop");
			if (Input.GetAxis ("Vertical") >= 1)
			{
				shopPanel.SetActive (true);
			}
		}
	}
}
