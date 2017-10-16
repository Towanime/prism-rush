using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlammerAttack : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit hit;

		if (Physics.SphereCast (this.transform.position, 1.0f, Vector3.down, out hit)) {
			if (hit.collider.tag == "Player") {
				anim.SetBool ("PlayerUnder", true);
				Debug.Log ("Slam Attack!");
			} else {
				anim.SetBool ("PlayerUnder", false);
			}
		}
	}
}
