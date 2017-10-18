using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour {

	public PlayerInput playerInput;
	public GameObject r1Button;
	public GameObject prismPartyText;
	public GameObject chargeBar;
	public GameObject prismParty;

	public SelectionWheelAnimationController selectWheelAnim;
	public SelectionWheelAnimationController bigXAnim;
	public DDRStateMachine ddrStateMachine;
	public Timer timer;

	public int maxCharge;
	public int abilitySuccess;

	public Slider slider;

	void Start () {
		maxCharge = 100;
		slider = chargeBar.GetComponent<Slider> ();
	}

	void Update () {

		if (slider.value >= maxCharge) {
			slider.value = maxCharge;
			if (selectWheelAnim.animPause == false) {
				r1Button.SetActive (true);
				prismPartyText.SetActive (true);
                if (prismParty.activeInHierarchy == false)
                {
                    chargeBar.SetActive(false);
                }
			}
		}

		if (slider.value >= maxCharge && selectWheelAnim.animPause == true) {
			
			r1Button.SetActive (false);
			prismPartyText.SetActive (false);

			if (abilitySuccess == 1) 
			{
				Debug.Log ("Pass");
				timer.timerOn = false;
				timer.timesUp = false;
				timer.slider.value += 100;
				ddrStateMachine.ddrFail = false;
				ddrStateMachine.ddrActive = false;
				prismParty.SetActive (true);
				abilitySuccess = 0;
			}

			if (abilitySuccess == 2 && bigXAnim.animEnd == true) {
				Debug.Log ("Fail");
				ddrStateMachine.ddrFail = false;
				ddrStateMachine.ddrActive = false;
				prismParty.SetActive (false);
				slider.value = 30;
				abilitySuccess = 0;
				bigXAnim.animEnd = false;
			}
		}
	}
}
