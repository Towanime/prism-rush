using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvHazard : MonoBehaviour {

	private GameObject player;

	private Score score;

	public int damageAmount;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		score = player.GetComponent<Score>();
	}
	void OnTriggerStay () {
		//DO SOME DAMAGE
		score.CurrentScore -= damageAmount;
		Debug.Log (score.CurrentScore);
	}

}
