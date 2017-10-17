using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenTransition : MonoBehaviour {

	public bool transition;

	public GameObject blackBackground;
	public GameObject background;
	public GameObject startButton;
	public GameObject startText;
	public GameObject titleText;

	void Update () {
		if (transition) {
			background.GetComponent<Animator> ().SetBool ("animEnd", true);
			startButton.GetComponent<Animator> ().SetBool ("animEnd", true);
			startText.GetComponent<Animator> ().SetBool ("animEnd", true);
			titleText.GetComponent<Animator> ().SetBool ("animEnd", true);
		}
	}
}
