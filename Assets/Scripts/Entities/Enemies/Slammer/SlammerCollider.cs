using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlammerCollider : MonoBehaviour {

	private GameObject player;
	public MovementStateMachine moveSM;

	private Score score;

	public int damageAmount;
	public float stunTime;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		score = player.GetComponent<Score>();
	} 

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Player Stunned!");
			score.CurrentScore -= damageAmount;
			StartCoroutine (StunPlayer());
			Debug.Log(score.CurrentScore);
		} else {
			 //Stun the slammer
		}
	}

	IEnumerator StunPlayer () {
		yield return null; //Wait a frame
		moveSM.playerInput.enabled = false;
		yield return new WaitForSeconds (stunTime); //Wait stunTime seconds
		moveSM.playerInput.enabled = true;
	}
}
