using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slammer : MonoBehaviour {

	//Setting up the player as the Slammer's target
	public GameObject target;
	//The minimum distance the player needs to be for the Slammer to chase her
	public float minDistance;
	//Max distance before the Slammer stops chasing
	public float maxDistance;
	
	//Slammer stats (speed and rotation)
	public float speed;
	public float rotationSpeed;

	//Starting transform for reference
	private Transform startingTransform;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player");
		startingTransform.position = this.transform.position;
		startingTransform.rotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float currentDistance = Vector3.Distance (target.transform.position, this.transform.position);
		if (currentDistance < minDistance) {
			this.transform.position = Vector3.Slerp (this.transform.position, target.transform.position, speed * Time.deltaTime);
			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, target.transform.rotation, rotationSpeed * Time.deltaTime);
		} else if (currentDistance > maxDistance) {
			this.transform.position = Vector3.Lerp (this.transform.position, startingTransform.position, speed);
			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, startingTransform.rotation, rotationSpeed);
		}
	}
}
