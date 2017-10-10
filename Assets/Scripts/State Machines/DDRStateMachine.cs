using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonsterLove.StateMachine;

public class DDRStateMachine : MonoBehaviour {
	
	public DDRStates startingState = DDRStates.Inactive;
	private StateMachine<DDRStates> fsm;
	private bool initialized;

	private int maxNumbers = 4;
	private List<int> arrowDirections;
	public List<int> finishedList;

	void Awake()
	{
		if (!initialized) Init();
	}

	void Init()
	{
		arrowDirections = new List<int>();
		finishedList = new List<int> ();
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

}