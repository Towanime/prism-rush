using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtDistance : MonoBehaviour {

	public Transform target;
	public float maxDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float currentDistance = Vector3.Distance (transform.position, target.position);
		if( currentDistance > maxDistance)
		{
			Vector3 currentDistanceVector = transform.position - target.position;
			target.position = transform.position + currentDistanceVector.normalized * maxDistance;
		}
	}
}
