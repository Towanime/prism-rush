using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlammerCollider : MonoBehaviour {

	private GameObject player;

	public int score;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		score = player.GetComponent<Score>().CurrentScore;
	} 

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Player Stunned!");
			score -= 10;
			Debug.Log(score);
		}
	}
}
