using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonsterLove.StateMachine;

public class DDRStateMachine : MonoBehaviour {
	
	public bool ddrActive;

	public GameObject selectionGlow;

	public SelectionWheelAnimationController SelectionWheelAnim;
	public SelectionGlowRotation glowPosition;
	public PlayerInput playerInput;

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

		if (SelectionWheelAnim.animPause) {
			ddrActive = true;
		}

		if (ddrActive == true) {
			fsm.ChangeState (DDRStates.Active);
			}
		}
		
	void Active_Enter(){
	}

	void Active_Update(){
		
		selectionGlow.SetActive(false);

		if (Input.GetKey (playerInput.config.up)) {
			fsm.ChangeState (DDRStates.Up);
		}
		if (Input.GetKey (playerInput.config.down)) {
			fsm.ChangeState (DDRStates.Down);
		}
		if (Input.GetKey (playerInput.config.left)) {
			fsm.ChangeState (DDRStates.Left);
		}
		if (Input.GetKey (playerInput.config.right)) {
			fsm.ChangeState (DDRStates.Right);
		}
	}

	void Down_Enter(){
		
		selectionGlow.SetActive(true);
		glowPosition.selectionGlowPosition = 4;
		glowPosition.SelectionGlowSetPosition ();
		fsm.ChangeState (DDRStates.Active);
	}

	void Up_Enter(){
		selectionGlow.SetActive(true);
		glowPosition.selectionGlowPosition = 2;
		glowPosition.SelectionGlowSetPosition ();
		fsm.ChangeState (DDRStates.Active);
	}

	void Left_Enter(){

		selectionGlow.SetActive(true);
		glowPosition.selectionGlowPosition = 3;
		glowPosition.SelectionGlowSetPosition ();
		fsm.ChangeState (DDRStates.Active);
	}
	void Right_Enter(){

		selectionGlow.SetActive(true);
		glowPosition.selectionGlowPosition = 1;
		glowPosition.SelectionGlowSetPosition ();
		fsm.ChangeState (DDRStates.Active);
	}
}