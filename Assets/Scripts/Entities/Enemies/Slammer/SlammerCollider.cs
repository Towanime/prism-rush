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
		player = GameObject.FindGameObjectWithTag ("Player"); //Fine the GameObject tagged "Player" and assign it to the player var
		score = player.GetComponent<Score>(); //Grab the Score component from player and assign it to the score var
	} 

	void OnTriggerEnter (Collider other) {
		//If the "other" is tagged "Player", affect the score based on the damageAmount var and run the StunPlayer coroutine
		if (other.tag == "Player") {
			Debug.Log ("Player Stunned!");
			score.CurrentScore -= damageAmount;
			StartCoroutine (StunPlayer());
			Debug.Log(score.CurrentScore);
		} else {
			 GetComponent<Animation>().Play ("SlamStun");
		}
	}

	IEnumerator StunPlayer () {
		yield return null; //Wait a frame
		moveSM.playerInput.enabled = false; //Disable the MovementStateMachine player input
		yield return new WaitForSeconds (stunTime); //Wait stunTime seconds
		moveSM.playerInput.enabled = true; //Enable the MovementStateMachine player input
	}

	void OnDestroy () {
		moveSM.playerInput.enabled = true; //Fallback in case the player kills the Slammer while she is stunned
	}
}
