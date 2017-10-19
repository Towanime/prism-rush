using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	private GameObject player;
	private Score score;

	private int highScore;
	public Text highScoreText;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player"); //Fine the GameObject tagged "Player" and assign it to the player var
		score = player.GetComponent<Score>(); //Grab the Score component from player and assign it to the score var
	}
	
	// Update is called once per frame
	void Update () {
		if (score.currentScore > highScore) {
			highScore = score.currentScore;
			PlayerPrefs.SetInt ("HighScore", highScore);
		}

		highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt ("HighScore", highScore).ToString();
	}
}
