using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArrowDown : MonoBehaviour {

	public SelectionGlowRotation glowPosition;
	public SelectionWheelAnimationController wheelAnim;

	public void Something ()
	{
		if (wheelAnim.animPause == true && Cursor.lockState == CursorLockMode.None) {
			glowPosition.selectionGlowPosition = 4;
			glowPosition.SelectionGlowSetPosition ();
		}
	}
}
