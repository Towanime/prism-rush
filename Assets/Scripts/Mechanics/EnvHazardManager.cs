using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvHazardManager : MonoBehaviour {

	public GameObject envHazard;

	void Update () {
		//If the player presses H, enable and disable the environmental hazard
		if (Input.GetKeyDown (KeyCode.H) && envHazard.activeInHierarchy == false) {
			envHazard.SetActive (true);
		} else if (Input.GetKeyDown (KeyCode.H) && envHazard.activeInHierarchy == true) {
			envHazard.SetActive (false);
		}
	}
}
