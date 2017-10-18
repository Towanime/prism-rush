using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreText : MonoBehaviour {

	public Score score;

	public Color red;
	public Color orange;
	public Color yellow;
	public Color blue;

	public string scoreString;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreString = score.CurrentScore.ToString ();

		this.GetComponent<Text> ().text = scoreString;

		if (score.currentScore > 1){
			this.GetComponent<Animator> ().SetBool ("danger", false);
		}

		if (score.CurrentScore <= 1) {
			this.GetComponent<Text> ().color = red;
			this.GetComponent<Animator> ().SetBool ("danger", true);
		} else if (score.CurrentScore <= 3) {
			this.GetComponent<Text> ().color = orange;
		} else if (score.CurrentScore <= 5) {
			this.GetComponent<Text> ().color = yellow;
		} else if (score.currentScore > 5) {
			this.GetComponent<Text> ().color = blue;
		}
	}
}
