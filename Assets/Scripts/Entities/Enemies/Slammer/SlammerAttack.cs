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
		if (Physics.SphereCast (this.transform.position, 1.0f, Vector3.down, out hit, Mathf.Infinity)) {
			if (hit.collider.tag == "Player") {
				anim.SetBool ("PlayerUnder", true);
			} else {
				anim.SetBool ("PlayerUnder", false);
			}
		}
	}
}