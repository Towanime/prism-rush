using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverScreenTransition : MonoBehaviour {

	public bool transition;

	public GameObject blackBackground;
	public GameObject gameoverText;
	public GameObject retryButton;

	public PlayerStateMachine playerStateMachine;

	void Update () {
		if (transition) {
			playerStateMachine.FSM.ChangeState(PlayerStates.Inactive);
			blackBackground.GetComponent<Animator> ().SetTrigger("Retry");
			gameoverText.GetComponent<Animator> ().SetTrigger("Retry");
			retryButton.GetComponent<Animator> ().SetBool("animEnd",true);
		}
	}
}
