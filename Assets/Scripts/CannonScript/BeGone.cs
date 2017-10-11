using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeGone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		DestroyObjectDelayed ();
	}

	void DestroyObjectDelayed()
	{
		// Kills the game object in 5 seconds after loading the object
		Destroy(gameObject, 5);
	}
}
