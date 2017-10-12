using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvHazardManager : MonoBehaviour {

	public GameObject envHazard;

	void Update () {
		if (Input.GetKeyDown (KeyCode.H) && envHazard.activeInHierarchy == false) {
			envHazard.SetActive(true);
		} else if (Input.GetKeyDown (KeyCode.H) && envHazard.activeInHierarchy == true) {
			envHazard.SetActive(false);
		}
	}
}
