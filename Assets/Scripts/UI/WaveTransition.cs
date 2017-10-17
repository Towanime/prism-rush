using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTransition : MonoBehaviour {

	public GameObject waveTransition;
	public string waveText;

	void Start () {
		waveText = "WAVE 1";
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text> ().text = waveText;
	}

	public void AnimReset () {
		waveTransition.SetActive (false);
	}
}
