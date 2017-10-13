using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slammer : MonoBehaviour {

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

		if (currentDirection.magnitude < detectionDistance) {
			this.transform.position = Vector3.Lerp (this.transform.position, new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z), moveSpeed * Time.deltaTime);
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, lookRotation, rotSpeed * Time.deltaTime);
		} else if (currentDirection.magnitude > detectionDistance) {
			this.transform.position = Vector3.Lerp (this.transform.position, slammerPos, moveSpeed * Time.deltaTime);
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, slammerRot, rotSpeed * Time.deltaTime);
		}

		RaycastHit hit;

		if (Physics.SphereCast (this.transform.position, 1.0f, Vector3.down, out hit)) {
			if (hit.collider.tag == "Player") {
				Debug.Log ("Player!");
			}
		}
	}
}