using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	#region PublicClasses
	public static GameControl gameControl;
	public Weapon weaponScript;
	#endregion

	#region PublicVariables
	public int playerLives;
	public int currentPoints;

	public string weapon = null;

	public Sprite[] pickUps;

	public bool hasKey = false;
	public bool hasWeapon;
	#endregion

	#region PrivateVariables
	int startingPoints = 0;
	float spawnDelay = .5f;
	#endregion

	#region GameOjectsAndComponents
	public GameObject spawnPoint;
	public GameObject player;

	public static CameraBehavior camB;
	Rigidbody2D rig;
	Text pointsText;
	Image slotOne;
	Image slotTwo;
	#endregion

	void Awake()
	{
		#region Singleton
		if (gameControl == null)
			gameControl = this;
		else if  (gameControl != null)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		#endregion
	}

	// Use this for initialization
	void Start () {

		currentPoints = startingPoints;
		gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();

		camB = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraBehavior> ();
		StartCoroutine(SpawnPlayer ());

		// UI initialization
		pointsText = GameObject.FindGameObjectWithTag ("PointsText").GetComponent<Text> ();
		slotOne = GameObject.FindGameObjectWithTag ("Inventory1").GetComponent<Image> ();
		slotTwo = GameObject.FindGameObjectWithTag ("Inventory2").GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		pointsText.text = "" + currentPoints;
		if (hasKey == true) {
			slotOne.sprite = pickUps[1];
		} else {
			slotOne.sprite = pickUps [0];
		}

		if (currentPoints < 0)
			currentPoints = 0;

	}

	public void AddPoints(int pointsToAdd){
		currentPoints += pointsToAdd;
	}

	public IEnumerator SpawnPlayer(){
		
		yield return new WaitForSeconds (spawnDelay);

		Debug.Log ("Spawn Attempt");
		spawnPoint = GameObject.FindGameObjectWithTag ("SpawnPoint");
		if (playerLives >=0) {
			Instantiate (player, spawnPoint.transform.position, spawnPoint.transform.rotation);
			camB.SetTarget ();
			rig = player.GetComponent<Rigidbody2D> ();
			rig.velocity = new Vector2 (0, 0);
			SetWeapon (weapon);
		} else {
			Debug.Log ("Game Over");
		}
	}

	 void DepricatePoints(){
		currentPoints -= 5;



	}

	public void SetWeapon(string weaponName)
	{
		weaponScript = GameObject.FindGameObjectWithTag ("Weapon").GetComponent<Weapon> ();
		weapon = weaponName;

		switch (weaponName) {

		default:
			slotTwo.sprite = pickUps [0];
			 hasWeapon = false;
			break;
		case "BaseballBat":
			slotTwo.sprite = pickUps [2];
			hasWeapon = true;
			weaponScript.SelectWeapon (weaponName);
			break;
		}
	}
	// Eliminate player

	public static void KillPlayer(Character player){
		Destroy (player.gameObject);
		gameControl.DepricatePoints ();
		gameControl.StartCoroutine (gameControl.SpawnPlayer ());
	}

	public static void KillCharacter (Character character){
		Destroy (character.gameObject, .15f);
		//gameControl.SpawnPlayer ();
	}
}
