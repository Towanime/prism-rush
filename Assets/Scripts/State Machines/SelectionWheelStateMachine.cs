﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class SelectionWheelStateMachine : MonoBehaviour {

	public PlayerInput playerInput;

	public WheelStates startingState = WheelStates.Default;

	public SelectionGlowRotation selectionGlowRotation;

	public SelectionWheelAnimationController SelectionWheelAnim;
	public SelectionWheelAnimationController SelectionWheelFade;

	public GameObject selectionWheel;
	public GameObject selectionFade;

	public Texture2D cursorTexture;

	private StateMachine<WheelStates> fsm;
	private bool initialized;

	void Awake()
	{
		if (!initialized) Init();
	}

	void Init()
	{
		fsm = StateMachine<WheelStates>.Initialize(this, startingState);
		Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
		initialized = true;
	}

	void Default_Enter()
	{
		selectionWheel.GetComponent<Animator> ().speed = 0;
		selectionWheel.GetComponent<Animator> ().SetInteger ("Select Wheel Toggle", 0);

		selectionFade.GetComponent<Animator> ().speed = 0;
		selectionFade.GetComponent<Animator> ().SetInteger ("Select Fade State", 0);
	}

	void Default_Update()
	{
		if (playerInput.selectionWheel) 
		{
			fsm.ChangeState (WheelStates.Selecting);
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void Selecting_Enter ()
	{
		selectionWheel.GetComponent<Animator> ().SetInteger ("Select Wheel Toggle", 2);
		selectionWheel.GetComponent<Animator> ().speed = 1;

		selectionFade.GetComponent<Animator> ().SetInteger ("Select Fade State", 2);
		selectionFade.GetComponent<Animator> ().speed = 1;
	}

	void Selecting_Update ()
	{
		if (playerInput.selectionWheel == true && SelectionWheelAnim.animPause == true && SelectionWheelFade.animPause == true) 
		{
			selectionWheel.GetComponent<Animator> ().SetInteger ("Select Wheel Toggle", 0);
			selectionWheel.GetComponent<Animator> ().speed = 0;

			selectionFade.GetComponent<Animator> ().SetInteger ("Select Fade State", 0);
			selectionFade.GetComponent<Animator> ().speed = 0;
		}
		if (playerInput.selectionWheel ==false &&
			SelectionWheelAnim.animPause == true &&
			selectionWheel.GetComponent<Animator> ().GetInteger ("Select Wheel Toggle") == 0 &&
			SelectionWheelFade.animPause == true &&
			selectionWheel.GetComponent<Animator> ().GetInteger ("Select Fade State") == 0)
		{
			selectionWheel.GetComponent<Animator> ().SetInteger ("Select Wheel Toggle", 1);
			selectionWheel.GetComponent<Animator> ().speed = 1;

			selectionFade.GetComponent<Animator> ().SetInteger ("Select Fade State", 1);
			selectionFade.GetComponent<Animator> ().speed = 1;

			SelectionWheelAnim.animPause = false;
			SelectionWheelFade.animPause = false;
		}
		if (SelectionWheelAnim.animEnd == true) 
		{
			selectionWheel.GetComponent<Animator> ().SetInteger ("Select Wheel Toggle", 0);

			selectionFade.GetComponent<Animator> ().SetInteger ("Select Fade State", 0);

			SelectionWheelAnim.animEnd = false;

			SelectionWheelFade.animEnd = false;

			Cursor.lockState = CursorLockMode.None;
			fsm.ChangeState (WheelStates.Default);
		}
	}

	void Selecting_Exit ()
	{
		selectionWheel.GetComponent<Animator> ().SetInteger ("Select Wheel Toggle", 0);

		selectionFade.GetComponent<Animator> ().SetInteger ("Select Fade State", 0);
	}
}
