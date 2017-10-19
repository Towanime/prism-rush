using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvHazardManager : MonoBehaviour {

	public GameObject envHazard;

	private AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();
		audio.enabled = false;
	}

	void Update () {
		//If the player presses H, enable and disable the environmental hazard
		if (Input.GetKeyDown (KeyCode.H) && envHazard.activeInHierarchy == false) {
			/* envHazard.SetActive (true); */ 
       		audio.enabled = true;
			audio.Play();
        	audio.Play(44100);
			Debug.Log(audio.isPlaying);
			if (audio.isPlaying == false) {
				envHazard.SetActive (true);
			}

		} else if (Input.GetKeyDown (KeyCode.H) && envHazard.activeInHierarchy == true) {
			/* envHazard.SetActive (false); */
		}
	}
}
