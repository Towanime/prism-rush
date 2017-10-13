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

	private Vector3 slammerPos;

	void Start () {
		target = GameObject.Find ("Player");
		slammerPos = this.transform.position;
	}
	
	void FixedUpdate () {
		Vector3 currentDirection = target.transform.position - this.transform.position;
		currentDirection = new Vector3 (currentDirection.x, 0, currentDirection.z);

		/*if(currentDirection.magnitude >= 0.2f)
			this.transform.position += currentDirection.normalized * speed * Time.deltaTime; */

		if (currentDirection.magnitude < detectionDistance) {
			this.transform.position = Vector3.Lerp (this.transform.position, new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z), speed * Time.deltaTime);
		} else if (currentDirection.magnitude > detectionDistance) {
			this.transform.position = Vector3.Lerp (this.transform.position, slammerPos, speed * Time.deltaTime);
		}
	}
}