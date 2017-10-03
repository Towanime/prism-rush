﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PhotonShotsButton : Graphic, IPointerEnterHandler {

	public SelectionGlowRotation glowPosition;
	public SelectionWheelAnimationController wheelAnim;

	protected override void OnPopulateMesh ( VertexHelper vh)
	{
		vh.Clear ();
	}

	public void OnPointerEnter (PointerEventData eventData) 
	{
		if (wheelAnim.animPause == true && Cursor.lockState == CursorLockMode.None) {
			glowPosition.selectionGlowPosition = 1;
			glowPosition.SelectionGlowSetPosition ();
		}
	}
}
