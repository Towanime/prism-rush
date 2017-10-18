using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlammerMovement : MonoBehaviour {

	//Setting up the player as the Slammer's target
	public GameObject target;
	//The minimum distance the player needs to be for the Slammer to chase her
	public float detectionDistance = 5.0f;
	
	//Slammer stats (speed and rotation)
	public float moveSpeed;

	public float rotSpeed;

	private Vector3 slammerPos;
	private Quaternion slammerRot;

	void Start () {
		target = GameObject.Find ("Player");
		slammerPos = this.transform.position;
		slammerRot = this.transform.rotation;
	}
	
	void FixedUpdate () {
		Vector3 currentDirection = target.transform.position - this.transform.position;
		currentDirection = new Vector3 (currentDirection.x, 0, currentDirection.z);
		Quaternion lookRotation = Quaternion.LookRotation(currentDirection);

		//If the distance between the player and slammer is smaller than the detection distance, chase the player
		if (currentDirection.magnitude < detectionDistance) {
			this.transform.position = Vector3.Lerp (this.transform.position, new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z), moveSpeed * Time.deltaTime);
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, lookRotation, rotSpeed * Time.deltaTime);
		// Else if the distance between the player and slammer is larger than the detection distance, return the slammer to its original position
		} else if (currentDirection.magnitude > detectionDistance) {
			this.transform.position = Vector3.Lerp (this.transform.position, slammerPos, moveSpeed * Time.deltaTime);
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, slammerRot, rotSpeed * Time.deltaTime);
		}
	}
}