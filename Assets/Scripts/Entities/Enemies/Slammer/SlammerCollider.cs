using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlammerCollider : MonoBehaviour {

	private GameObject player;

	private int score;

	public int health;

	public int damageAmount;
	public float stunTime;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		score = player.GetComponent<Score>().CurrentScore;
	} 

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Player Stunned!");
			score -= damageAmount;
			StartCoroutine (StunPlayer());
			Debug.Log(score);
		} else {
			 //Stun the slammer
		}
	}

	IEnumerator StunPlayer () {
		yield return null; //Wait a frame
		player.GetComponent<PlayerController>().enabled = false; //Grab the player's Player Controller and disable it
		yield return new WaitForSeconds (stunTime); //Wait stunTime seconds
		player.GetComponent<PlayerController>().enabled = true; //Grab the player's Player Controller and enable it
	}
}
