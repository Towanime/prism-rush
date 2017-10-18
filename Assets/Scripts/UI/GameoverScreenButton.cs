using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class GameoverScreenButton : MonoBehaviour, IPointerDownHandler // required interface when using the OnPointerDown method.
{
    public GameStateMachine gameStateMachine;
	public GameoverScreenTransition GameoverScreenTransition;

	public GameObject blackBackground;

	public void OnPointerDown (PointerEventData eventData) 
	{
		GameoverScreenTransition.transition = true;
	}

	public void animEnd(){
		blackBackground.GetComponent<Animator> ().enabled = true;
        gameStateMachine.FSM.ChangeState(GameStates.Running);
    }
}
