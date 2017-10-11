﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonsterLove.StateMachine;

public class DDRStateMachine : MonoBehaviour {
	
	public bool ddrActive;

	public GameObject selectionGlow;

	public SelectionWheelAnimationController SelectionWheelAnim;
	public SelectionGlowRotation glowPosition;
	public SelectionGlowAnimController selectGlowAnim;
	public PlayerInput playerInput;
	public ChargeBar chargeBar;

	public DDRStates startingState = DDRStates.Inactive;
	private StateMachine<DDRStates> fsm;
	private bool initialized;

	private int blue;
	private int red;
	private int green;
	private int yellow;

	private int maxNumbers = 4;
	private List<int> arrowDirections;
	public List<int> playerDirections;
	public List<int> finishedList;

	void Awake()
	{
		if (!initialized) Init();
	}

	void Init()
	{
		arrowDirections = new List<int>();
		finishedList = new List<int> ();
		blue = 0;
		red = 1;
		green = 2;
		yellow = 3;
		fsm = StateMachine<DDRStates>.Initialize(this, startingState);
		initialized = true;
	}

	void Inactive_Enter(){

		if (playerDirections.Count >= 4) {
			if (CheckMatch ()) {
				chargeBar.abilitySuccess = 1;
			} 

			if (CheckMatch () == false) {
				chargeBar.abilitySuccess = 2;
			}

			playerDirections.Clear ();
			finishedList.Clear ();
		}

		for(int i = 0; i < maxNumbers; i++){
			this.arrowDirections.Add (i);
		}
		for(int i = 0; i< maxNumbers; i ++){
			int ranNum = arrowDirections[Random.Range(0,arrowDirections.Count)];
			finishedList.Add(ranNum);
			arrowDirections.Remove (ranNum);
		}

	}
		
	void Inactive_Update(){

		if (ddrActive == true) {
			fsm.ChangeState (DDRStates.Active);
			}
		}
		
	void Active_Enter(){
	}

	void Active_Update(){
		
		if(selectGlowAnim.animEnd == true){
			selectionGlow.SetActive(false);
			selectGlowAnim.animEnd = false;
		}

		if (playerDirections.Count >= 4) {

			fsm.ChangeState (DDRStates.Inactive);
			}
			
		if (Input.GetKeyDown(playerInput.config.up)) {
			fsm.ChangeState (DDRStates.Up);
		}
		if (Input.GetKeyDown(playerInput.config.down)) {
			fsm.ChangeState (DDRStates.Down);
		}
		if (Input.GetKeyDown(playerInput.config.left)) {
			fsm.ChangeState (DDRStates.Left);
		}
		if (Input.GetKeyDown(playerInput.config.right)) {
			fsm.ChangeState (DDRStates.Right);
		}
	}
		

	void Right_Enter(){
		playerDirections.Add (0);
		selectionGlow.SetActive(true);
		glowPosition.selectionGlowPosition = 1;
		glowPosition.SelectionGlowSetPosition ();
		fsm.ChangeState (DDRStates.Active);
	}

	void Down_Enter(){
		
		playerDirections.Add (1);
		selectionGlow.SetActive(true);
		glowPosition.selectionGlowPosition = 4;
		glowPosition.SelectionGlowSetPosition ();
		fsm.ChangeState (DDRStates.Active);
	}

	void Up_Enter(){
		playerDirections.Add (3);
		selectionGlow.SetActive(true);
		glowPosition.selectionGlowPosition = 2;
		glowPosition.SelectionGlowSetPosition ();
		fsm.ChangeState (DDRStates.Active);
	}

	void Left_Enter(){
		playerDirections.Add (2);
		selectionGlow.SetActive(true);
		glowPosition.selectionGlowPosition = 3;
		glowPosition.SelectionGlowSetPosition ();
		fsm.ChangeState (DDRStates.Active);
	}


	bool CheckMatch() {
		for (int i = 0; i < finishedList.Count; i++) {
			if (finishedList[i] != playerDirections[i])
				return false;
		}
		return true;
	}
}