using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : Hazard {

	public void OnTriggerStay(Collider other)
	{
		DoDamage(other.gameObject);
	}
}
