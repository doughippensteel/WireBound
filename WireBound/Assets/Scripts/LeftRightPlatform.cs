using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightPlatform : MonoBehaviour {

	float speed = 3;

	public Transform platform;
	public Transform leftWaypoint;
	public Transform rightWaypoint;
	public Vector3 targetPosition;
	bool goingLeft = false;


	// Use this for initialization
	void Start () {
		platform = transform.Find ("MovingPlat").transform;
		leftWaypoint = transform.Find ("LeftWaypoint").transform;
		rightWaypoint = transform.Find ("RightWaypoint").transform;


	}
	
	// Update is called once per frame
	void Update () {
		if (platform.position == targetPosition) {
			goingLeft = !goingLeft;
		}

		Move ();
	}
	void Move()
	{
		switch (goingLeft) {
		case false:
			targetPosition = rightWaypoint.position;
			platform.position = Vector2.MoveTowards (platform.position, rightWaypoint.position, speed * Time.deltaTime);
			break;
		case true:
			targetPosition = leftWaypoint.position;
			platform.position = Vector2.MoveTowards (platform.position, leftWaypoint.position, speed * Time.deltaTime);
			break;
			
		}
	}

}
