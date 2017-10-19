using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStartScreen : MonoBehaviour {
    public GameStateMachine gameStateMachine;
	public GameObject startScreen;
	public StartScreenTransition startScreenTransition;

	public void boom(){
		startScreenTransition.transition = false;
		startScreen.SetActive (false);
        gameStateMachine.FSM.ChangeState(GameStates.Running);
	}
}
