using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRange : MonoBehaviour {

	public LookAtDistance[] controllers;
	public float masterRange;
	//public float maxDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < controllers.Length; ++i)
		{
			controllers[i].maxDistance = masterRange;
		}
	}
}
