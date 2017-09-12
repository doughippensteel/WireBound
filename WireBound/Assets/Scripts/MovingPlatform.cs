using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	float speed = 3;

	public Transform platform;
	public Transform waypointA;
	public Transform waypointB;
	public Vector3 targetPosition;
	bool towardsA = false;


	// Use this for initialization
	void Start () {
		platform = transform.Find ("MovingPlat").transform;
		waypointA = transform.Find ("WaypointA").transform;
		waypointB = transform.Find ("WaypointB").transform;


	}

	// Update is called once per frame
	void Update () {
		if (platform.position == targetPosition) {
			towardsA = !towardsA;
		}

		Move ();
	}
	void Move()
	{
		switch (towardsA) {
		case false:
			targetPosition = waypointB.position;
			platform.position = Vector2.MoveTowards (platform.position, waypointB.position, speed * Time.deltaTime);
			break;
		case true:
			targetPosition = waypointA.position;
			platform.position = Vector2.MoveTowards (platform.position, waypointA.position, speed * Time.deltaTime);
			break;

		}
	}

}