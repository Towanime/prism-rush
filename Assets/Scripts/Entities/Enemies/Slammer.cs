using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slammer : MonoBehaviour {

	//Setting up the player as the Slammer's target
	public GameObject target;
	//The minimum distance the player needs to be for the Slammer to chase her
	public float detectionDistance = 5.0f;
	
	//Slammer stats (speed and rotation)
	public float speed;

	private Transform slammerTransform;

	void Start () {
		target = GameObject.Find("Player");
		slammerTransform = this.transform;
	}
	
	void FixedUpdate () {
		float currentDistance = Vector3.Distance (target.transform.position, this.transform.position);

		if (currentDistance < detectionDistance) {
			this.transform.position = Vector3.Slerp (this.transform.position, target.transform.position, speed * Time.deltaTime);
		}
	}
}
