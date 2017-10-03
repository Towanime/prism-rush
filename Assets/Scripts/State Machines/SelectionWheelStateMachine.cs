using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class SelectionWheelStateMachine : MonoBehaviour {

	public PlayerInput playerInput;

	public WheelStates startingState = WheelStates.Default;

	public SelectionGlowRotation selectionGlowRotation;
	public SelectionWheelAnimationController SelectionWheelAnim;
	public SelectionWheelAnimationController SelectionWheelFade;

	public GameObject selectionFade;
	public GameObject selectionWheel;

	private StateMachine<WheelStates> fsm;
	private bool initialized;

	void Awake()
	{
		if (!initialized) Init();
	}

	void Init()
	{
		fsm = StateMachine<WheelStates>.Initialize(this, startingState);
		initialized = true;
	}

	void Default_Enter()
	{
		SelectionWheelAnim.GetComponent<Animator> ().speed = 0;
		SelectionWheelFade.GetComponent<Animator> ().speed = 0;
		SelectionWheelAnim.GetComponent<Animator> ().Play ("Selection Wheel Anim", 1, 0);
		SelectionWheelFade.GetComponent<Animator> ().Play ("Selection Fade Anim", 1, 0);
	}

	void Default_Update()
	{
		if (playerInput.selectionWheel) 
		{
			fsm.ChangeState (WheelStates.Selecting);
		}
	}

	public void Selecting_Enter ()
	{
		if (SelectionWheelAnim.animPause == false || SelectionWheelFade.animPause == false) 
		{
			selectionFade.GetComponent<Animator> ().speed = 1;
			selectionWheel.GetComponent<Animator> ().speed = 1;
		}
	}

	void Selecting_Update ()
	{
		if (playerInput.selectionWheel != true) 
		{
			Selecting_Exit ();
		}
		if (SelectionWheelAnim.animEnd == true || SelectionWheelFade.animEnd == true) 
		{
			fsm.ChangeState (WheelStates.Default);
			SelectionWheelAnim.animEnd = false;
			SelectionWheelFade.animEnd = false;
		}
	}

	void Selecting_Exit ()
	{
		SelectionWheelAnim.animPause = false;
		SelectionWheelFade.animPause = false;
		selectionFade.GetComponent<Animator> ().speed = 1;
		selectionWheel.GetComponent<Animator> ().speed = 1;
	}

	void PhotonShotsActive_Enter () 
	{
		selectionGlowRotation.selectionGlowPosition = 1;
		selectionGlowRotation.SelectionGlowSetPosition();
	}
	void FlashActive_Enter () 
	{
		selectionGlowRotation.selectionGlowPosition = 2;
		selectionGlowRotation.SelectionGlowSetPosition();
	}
	void LightBombActive_Enter () 
	{
		selectionGlowRotation.selectionGlowPosition = 3;
		selectionGlowRotation.SelectionGlowSetPosition();
	}
	void PrismPartyActive_Enter () 
	{
		selectionGlowRotation.selectionGlowPosition = 4;
		selectionGlowRotation.SelectionGlowSetPosition();
	}
}
