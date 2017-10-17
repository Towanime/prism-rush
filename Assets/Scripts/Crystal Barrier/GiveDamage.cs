using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour 
{

	HealthCasters HC;

	void Start()
	{
		HC = GetComponent<HealthCasters> ();
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Enemy") {
			HC.currentHealth -= 1;
			
		}
	}
}
