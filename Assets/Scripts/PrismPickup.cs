﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismPickup : MonoBehaviour {

	public GameObject particlePrefab;
	
	//Score and size values
	public float scoreValue = 100;
	public float sizeMultiplier = 1;

	//Movement and "juice"
	public float rotationSpeed = 85.0f;
	public float amplitudeAmount = 0.25f;
	public float frequencySpeed = 0.75f;

	//Position storage
	private Vector3 posOffest = new Vector3 ();
	private Vector3 tempPos = new Vector3 ();

	// Use this for initialization
	void Start () {
		//Store the starting position & rotation of the object
		posOffest = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Spin object on Y axis
		transform.Rotate (new Vector3 (0, rotationSpeed * Time.deltaTime, 0));

		//Float up and down with a Sin()
		tempPos = posOffest;
		tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequencySpeed) * amplitudeAmount;
		transform.position = tempPos;
	}

	//Use for when the Player enters the trigger of the Prism
	void OnTriggerEnter (Collider other) {
		//If the other object is tagged as "Player", deactivate the collectible
		if(other.gameObject.CompareTag ("Player")) {
			Instantiate (particlePrefab, this.transform.position, Quaternion.Euler (90, 0, 0));
			this.gameObject.SetActive (false);
		}
	}
}
