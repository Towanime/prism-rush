using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMe : MonoBehaviour {

	public Transform leader;
	public float followSharpness = 1.0f;

	Vector3 followOffset;

	void Start()
	{
		// Cache the initial offset at time of load/spawn:
		followOffset = transform.position - leader.position;
	}

	void LateUpdate () 
	{
		// Apply that offset to get a target position.
		Vector3 targetPosition = leader.position + followOffset;

		// Keep our y position unchanged.
		targetPosition.y = transform.position.y;

		// Smooth follow.    
		transform.position += (targetPosition - transform.position) * followSharpness;
	}
}
