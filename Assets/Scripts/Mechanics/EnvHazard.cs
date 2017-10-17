using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvHazard : MonoBehaviour {

	private GameObject player;

	private int score;

	public int damageAmount;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		score = player.GetComponent<Score>().CurrentScore;
	}
	void OnTriggerStay () {
		//DO SOME DAMAGE
		score -= damageAmount;
		Debug.Log (score);
	}

}
