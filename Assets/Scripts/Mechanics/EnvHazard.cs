using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvHazard : MonoBehaviour {

	private GameObject player;

	private Score score;

	public int damageAmount;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player"); //Fine the GameObject tagged "Player" and assign it to the player var
		score = player.GetComponent<Score>(); //Grab the Score component from player and assign it to the score var
	}
	void OnTriggerStay () {
		score.CurrentScore -= damageAmount; //Affect the score based on the damageAmount var
		Debug.Log (score.CurrentScore);
	}

}
