using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimunYPos : MonoBehaviour 
{
	public float minPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if (transform.position.y < minPos) 
		{
			Vector3 pos = transform.position;
			pos.y = minPos;
			transform.position = pos;
		}
	}
}
