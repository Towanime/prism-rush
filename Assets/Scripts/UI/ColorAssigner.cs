using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ColorAssigner : MonoBehaviour {

	public DDRStateMachine ddrStateMachine;

	public GameObject circleOne;
	public GameObject circleTwo;
	public GameObject circleThree;
	public GameObject circleFour;

	public Color blue;
	public Color red;
	public Color green;
	public Color yellow;

	public void AssignColors() {

		if (ddrStateMachine.finishedList.ElementAt (0).Equals (0)) {
			circleOne.GetComponent<Image> ().color = blue;
		}
		if (ddrStateMachine.finishedList.ElementAt (0).Equals (1)) {
			circleOne.GetComponent<Image> ().color = red;
		}
		if (ddrStateMachine.finishedList.ElementAt (0).Equals (2)) {
			circleOne.GetComponent<Image> ().color = green;
		}
		if (ddrStateMachine.finishedList.ElementAt (0).Equals (3)) {
			circleOne.GetComponent<Image> ().color = yellow;
		}

		if (ddrStateMachine.finishedList.ElementAt (1).Equals (0)) {
			circleTwo.GetComponent<Image> ().color = blue;
		}
		if (ddrStateMachine.finishedList.ElementAt (1).Equals (1)) {
			circleTwo.GetComponent<Image> ().color = red;
		}
		if (ddrStateMachine.finishedList.ElementAt (1).Equals (2)) {
			circleTwo.GetComponent<Image> ().color = green;
		}
		if (ddrStateMachine.finishedList.ElementAt (1).Equals (3)) {
			circleTwo.GetComponent<Image> ().color = yellow;
		}

		if (ddrStateMachine.finishedList.ElementAt (2).Equals (0)) {
			circleThree.GetComponent<Image> ().color = blue;
		}
		if (ddrStateMachine.finishedList.ElementAt (2).Equals (1)) {
			circleThree.GetComponent<Image> ().color = red;
		}
		if (ddrStateMachine.finishedList.ElementAt (2).Equals (2)) {
			circleThree.GetComponent<Image> ().color = green;
		}
		if (ddrStateMachine.finishedList.ElementAt (2).Equals (3)) {
			circleThree.GetComponent<Image> ().color = yellow;
		}

		if (ddrStateMachine.finishedList.ElementAt (3).Equals (0)) {
			circleFour.GetComponent<Image> ().color = blue;
		}
		if (ddrStateMachine.finishedList.ElementAt (3).Equals (1)) {
			circleFour.GetComponent<Image> ().color = red;
		}
		if (ddrStateMachine.finishedList.ElementAt (3).Equals (2)) {
			circleFour.GetComponent<Image> ().color = green;
		}
		if (ddrStateMachine.finishedList.ElementAt (3).Equals (3)) {
			circleFour.GetComponent<Image> ().color = yellow;
		}
	}
}
