using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvHazardManager : MonoBehaviour {

	public GameObject envHazard;

	private AudioSource audioClip;

	void Start () {
		audioClip = GetComponent<AudioSource>();
		audioClip.enabled = false;
	}

	void Update () {
		//If the player presses H, enable and disable the environmental hazard
		if (Input.GetKeyDown (KeyCode.H) && envHazard.activeInHierarchy == false) {
       		audioClip.enabled = true;
			audioClip.Play ();
			Invoke ("TurnOnHazard", audioClip.clip.length);
			

		} else if (Input.GetKeyDown (KeyCode.H) && envHazard.activeInHierarchy == true) {
			/* envHazard.SetActive (false); */
		}
	}

	void TurnOnHazard () {
		envHazard.SetActive (true);
	}
}
