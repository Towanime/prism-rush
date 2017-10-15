using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonsterLove.StateMachine;

public class SelectionWheelStateMachine : MonoBehaviour {

	public PlayerInput playerInput;
	public WheelStates startingState = WheelStates.Default;
	public DDRStateMachine ddrStateMachine;
	public SelectionWheelAnimationController selectionWheelAnim;
	public SelectionWheelAnimationController selectionWheelFade;
	public SelectionWheelAnimationController comboColors;
	public Timer timer;

	public GameObject selectionGlow;
	public GameObject selectionWheel;
	public GameObject selectionFade;
	public GameObject comboColorAnim;
	public GameObject chargeBar;
	public GameObject bigX;

	public Slider slider;

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
		slider = chargeBar.GetComponent<Slider> ();
		Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
		initialized = true;
	}

	void Default_Enter()
	{
		selectionWheel.GetComponent<Animator> ().speed = 0;
		selectionWheel.GetComponent<Animator> ().SetInteger ("Select Wheel Toggle", 0);

		selectionFade.GetComponent<Animator> ().speed = 0;
		selectionFade.GetComponent<Animator> ().SetInteger ("Select Fade State", 0);

		comboColorAnim.GetComponent<Animator> ().speed = 0;
		comboColorAnim.GetComponent<Animator> ().SetInteger ("Combo Colors Toggle", 0);
	}

	void Default_Update()
	{
		if (playerInput.selectionWheel && slider.value == 100) 
		{
			chargeBar.SetActive (false);
			ddrStateMachine.ddrActive = true;
			fsm.ChangeState (WheelStates.Selecting);
		}
	}

	public void Selecting_Enter ()
	{
		selectionWheel.GetComponent<Animator> ().SetInteger ("Select Wheel Toggle", 2);
		selectionWheel.GetComponent<Animator> ().speed = 1;

		selectionFade.GetComponent<Animator> ().SetInteger ("Select Fade State", 2);
		selectionFade.GetComponent<Animator> ().speed = 1;

		comboColorAnim.GetComponent<Animator> ().SetInteger ("Combo Colors Toggle", 2);
		comboColorAnim.GetComponent<Animator> ().speed = 1;

		selectionGlow.SetActive(false);
		timer.timerOn = true;
	}

	void Selecting_Update ()
	{
		if (playerInput.selectionWheel == true && selectionWheelAnim.animPause == true && selectionWheelFade.animPause == true && comboColors.animPause == true) 
		{

			selectionWheel.GetComponent<Animator> ().SetInteger ("Select Wheel Toggle", 0);
			selectionWheel.GetComponent<Animator> ().speed = 0;

			selectionFade.GetComponent<Animator> ().SetInteger ("Select Fade State", 0);
			selectionFade.GetComponent<Animator> ().speed = 0;

			comboColorAnim.GetComponent<Animator> ().SetInteger ("Combo Colors Toggle", 0);
			comboColorAnim.GetComponent<Animator> ().speed = 0;

		}
		if (
			selectionWheelAnim.animPause == true &&
			selectionWheelFade.animPause == true &&
			comboColors.animPause == true &&
			ddrStateMachine.ddrActive == false)
		{
			selectionWheel.GetComponent<Animator> ().SetInteger ("Select Wheel Toggle", 1);
			selectionWheel.GetComponent<Animator> ().speed = 1;

			selectionFade.GetComponent<Animator> ().SetInteger ("Select Fade State", 1);
			selectionFade.GetComponent<Animator> ().speed = 1;

			comboColorAnim.GetComponent<Animator> ().SetInteger ("Combo Colors Toggle", 1);
			comboColorAnim.GetComponent<Animator> ().speed = 1;

			selectionWheelAnim.animPause = false;
			selectionWheelFade.animPause = false;
			comboColors.animPause = false;
		}
		if (selectionWheelAnim.animEnd == true && selectionWheelFade.animEnd == true && comboColors.animEnd == true) 
		{
			selectionWheel.GetComponent<Animator> ().SetInteger ("Select Wheel Toggle", 0);

			selectionFade.GetComponent<Animator> ().SetInteger ("Select Fade State", 0);

			comboColorAnim.GetComponent<Animator> ().SetInteger ("Combo Colors Toggle", 0);

			selectionWheelAnim.animEnd = false;

			selectionWheelFade.animEnd = false;

			comboColors.animEnd = false;

			bigX.SetActive (false);

			ddrStateMachine.ddrFail = false;

			Cursor.lockState = CursorLockMode.None;
			fsm.ChangeState (WheelStates.Default);
		}
	}

	void Selecting_Exit ()
	{
		selectionWheel.GetComponent<Animator> ().SetInteger ("Select Wheel Toggle", 0);

		selectionFade.GetComponent<Animator> ().SetInteger ("Select Fade State", 0);

		comboColorAnim.GetComponent<Animator> ().SetInteger ("Combo Colors Toggle", 0);

		chargeBar.SetActive (true);
	}
}
