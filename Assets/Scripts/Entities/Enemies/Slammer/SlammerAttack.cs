using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlammerAttack : MonoBehaviour {

	private Animator anim;

	void Start () {
		anim = GetComponentInChildren<Animator>();
	}
	
	void FixedUpdate () {
		RaycastHit hit;

		//Cast a sphere downwards, if it hits a collider tagged "player", play the attack animation
		if (Physics.SphereCast (this.transform.position, 2.5f, Vector3.down, out hit, Mathf.Infinity)) {
			if (hit.collider.tag == "Player") {
				GetComponentInChildren<Animation>().Play ("SlamAttack");
			} else {
				GetComponentInChildren<Animation>().Play ();
			}
		}
	}
}