using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismParty : MonoBehaviour {

	public ChargeBar chargeBar;

	public GameObject prismParty;

	public float speed;

	void Update () {

		if (chargeBar.slider.value <= 0) {
			chargeBar.slider.value = 0;
			prismParty.SetActive (false);
        } else {
			chargeBar.slider.value -= speed * Time.deltaTime;
			chargeBar.r1Button.SetActive (false);
			chargeBar.prismPartyText.SetActive (false);
		}
	}
}
