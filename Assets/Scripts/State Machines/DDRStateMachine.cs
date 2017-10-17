using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonsterLove.StateMachine;
using System.Linq;

public class DDRStateMachine : MonoBehaviour {
	
	public bool ddrActive;
	public bool ddrFail;

	public GameObject selectionGlow;
	public GameObject checkmark1;
	public GameObject checkmark2;
	public GameObject checkmark3;
	public GameObject checkmark4;
	public GameObject bigX;

	public SelectionGlowRotation glowPosition;
	public SelectionGlowAnimController selectGlowAnim;
	public SelectionWheelAnimationController bigXAnim;
	public PlayerInput playerInput;
	public ChargeBar chargeBar;
	public ColorAssigner colorAssigner;
	public Timer timer;

	public DDRStates startingState = DDRStates.Inactive;
	public StateMachine<DDRStates> fsm;
	private bool initialized;

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
		fsm = StateMachine<DDRStates>.Initialize(this, startingState);
		initialized = true;
	}

	void Inactive_Enter(){

		if (ddrFail == true){
			bigX.SetActive (true);
			playerDirections.Clear ();
			finishedList.Clear ();
		}

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
		for(int i = 0; i < maxNumbers; i++){
			int ranNum = arrowDirections[Random.Range(0,arrowDirections.Count)];
			finishedList.Add(ranNum);
			arrowDirections.Remove (ranNum);
		}

		checkmark1.SetActive (false);
		checkmark2.SetActive (false);
		checkmark3.SetActive (false);
		checkmark4.SetActive (false);

		colorAssigner.AssignColors ();

	
	}
		
	void Inactive_Update(){

		if (ddrActive == true) {
			fsm.ChangeState (DDRStates.Active);
			}
	}
		
	void Active_Exit(){
        //CheckLastInput();
		/*if (playerDirections.Count != 0) {
			
			if (finishedList.ElementAt (0) != playerDirections.ElementAt (0)) {
				ddrFail = true;
				timer.slider.value = 0;
				chargeBar.abilitySuccess = 2;
				fsm.ChangeState (DDRStates.Inactive);
                return;
			} else {
				checkmark1.SetActive (true);
                return;
            }
			if (playerDirections.Count <= 1 && finishedList.ElementAt (1) != playerDirections.ElementAt (1)) {
				ddrFail = true;
				timer.slider.value = 0;
				chargeBar.abilitySuccess = 2;
				fsm.ChangeState (DDRStates.Inactive);
                return;
            } else {
				checkmark2.SetActive (true);
                return;
            }
			if (playerDirections.Count <= 2 && finishedList.ElementAt (2) != playerDirections.ElementAt (2)) {
				ddrFail = true;
				timer.slider.value = 0;
				chargeBar.abilitySuccess = 2;
				fsm.ChangeState (DDRStates.Inactive);
                return;
            } else {
				checkmark3.SetActive (true);
                return;
            }
			if (playerDirections.Count <= 3 && finishedList.ElementAt (3) != playerDirections.ElementAt (3)) {
				ddrFail = true;
				timer.slider.value = 0;
				chargeBar.abilitySuccess = 2;
				fsm.ChangeState (DDRStates.Inactive);
                return;
            } else {
				checkmark4.SetActive (true);
                return;
            }
		}*/
	}

	void Active_Update(){
		
		if (timer.timesUp == true) {
			ddrFail = true;
			chargeBar.abilitySuccess = 2;
			fsm.ChangeState (DDRStates.Inactive);
			timer.timerOn = false;
		}

		if(selectGlowAnim.animEnd == true){
			selectionGlow.SetActive(false);
			selectGlowAnim.animEnd = false;
		}

		if (playerDirections.Count >= 4) {

			fsm.ChangeState (DDRStates.Inactive);
			}
		if(ddrFail == false){	
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
	}
		

	void Right_Enter(){
		playerDirections.Add (0);
		selectionGlow.SetActive(true);
		glowPosition.selectionGlowPosition = 1;
		glowPosition.SelectionGlowSetPosition ();
        CheckLastInput();
        fsm.ChangeState (DDRStates.Active);
	}

	void Down_Enter(){
		
		playerDirections.Add (1);
		selectionGlow.SetActive(true);
		glowPosition.selectionGlowPosition = 4;
		glowPosition.SelectionGlowSetPosition ();
        CheckLastInput();
        fsm.ChangeState (DDRStates.Active);
	}

	void Up_Enter(){
		playerDirections.Add (3);
		selectionGlow.SetActive(true);
		glowPosition.selectionGlowPosition = 2;
		glowPosition.SelectionGlowSetPosition ();
        CheckLastInput();
        fsm.ChangeState (DDRStates.Active);
	}

	void Left_Enter(){
		playerDirections.Add (2);
		selectionGlow.SetActive(true);
		glowPosition.selectionGlowPosition = 3;
		glowPosition.SelectionGlowSetPosition ();
        CheckLastInput();
        fsm.ChangeState (DDRStates.Active);
	}


	bool CheckMatch() {
		for (int i = 0; i < finishedList.Count; i++) {
			if (finishedList[i] != playerDirections[i])
				return false;
		}
		return true;
	}

    private void CheckLastInput()
    {
        if(playerDirections.Count == 0)
        {
            return;
        }
        // get index of last input
        int playerIndex = playerDirections.Count - 1;
        // compare inputs depending of the index
        if (finishedList[playerIndex] != playerDirections[playerIndex])
        {
            ddrFail = true;
            timer.slider.value = 0;
            chargeBar.abilitySuccess = 2;
            fsm.ChangeState(DDRStates.Inactive);
        }
        else
        {
            // sucess then show the correct checkmark
            switch (playerIndex)
            {
                case 0:
                    checkmark1.SetActive(true);
                    break;
                case 1:
                    checkmark2.SetActive(true);
                    break;
                case 2:
                    checkmark3.SetActive(true);
                    break;
                case 3:
                    checkmark4.SetActive(true);
                    break;
            }
        }
    }
}