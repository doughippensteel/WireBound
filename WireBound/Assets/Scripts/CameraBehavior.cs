using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {
	public static CameraBehavior camB;

	public GameObject target;

	GameObject player;
	public GameObject defaultTarget;

	Vector3 cameraOffset;
	bool playerNull = false;

	// Use this for initialization
	void Start () {
		camB = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraBehavior> ();
		defaultTarget = GameObject.FindGameObjectWithTag ("DefaultTarget");
		target = defaultTarget;
		}
	public void SetTarget(){
		
		player = GameObject.FindGameObjectWithTag ("Player");

		if (player != null){ 
			target = player;
		} else if (player == null) {target = defaultTarget ;
		}
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, -10);
		cameraOffset = transform.position - target.transform.position;
	}


	void Update(){
		


		

	}
	
	// Update is called once per frame
	void LateUpdate () {

		this.transform.position = target.transform.position + cameraOffset;
		
	}

}
