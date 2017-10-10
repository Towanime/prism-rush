using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour {

	public PlayerInput playerInput;
	public GameObject r1Button;
	public GameObject prismPartyText;
	public GameObject chargeBar;
	public SelectionWheelAnimationController selectWheelAnim;
	public int maxCharge;
	private int abilitySuccess = 0;
	private Slider slider;


	void Start () {
		maxCharge = 100;
		slider = chargeBar.GetComponent<Slider> ();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftControl)) 
		{
			slider.value += 10;
		}

		if (slider.value >= maxCharge) {
			slider.value = maxCharge;
			if (selectWheelAnim.animPause == false) {
				r1Button.SetActive (true);
				prismPartyText.SetActive (true);
				chargeBar.SetActive (false);
			}
		}

		if (r1Button.activeSelf == true && slider.value >= maxCharge && selectWheelAnim.animPause == true) {
			
			r1Button.SetActive (false);
			prismPartyText.SetActive (false);

			if (abilitySuccess == 1) 
			{
				slider.value -= 100;
				abilitySuccess = 0;
			}

			if (abilitySuccess == 2) 
			{
				slider.value -= 30;
				abilitySuccess = 0;
			}
		}
	}
}
