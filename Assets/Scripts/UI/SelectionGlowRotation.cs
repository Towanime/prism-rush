using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionGlowRotation : MonoBehaviour {
	
	public GameObject selectionGlow;
	public int selectionGlowPosition;

	private Vector3 selectionGlowRotation;
	private Vector3 selectionGlowAngle;


	void Start () 
	{
		selectionGlowRotation = selectionGlow.GetComponent<RectTransform> ().rotation.eulerAngles;
		selectionGlowAngle = selectionGlowRotation;
		selectionGlowAngle.z = 180;
		selectionGlowPosition = 1;
		selectionGlow.GetComponent<RectTransform> ().rotation = Quaternion.Euler(selectionGlowAngle);

	}

	public void SelectionGlowSetPosition ()
	{

		if (selectionGlowPosition == 1) {
			
			selectionGlowAngle = selectionGlowRotation;
			selectionGlowAngle.z = 180;
			selectionGlow.GetComponent<RectTransform> ().rotation = Quaternion.Euler (selectionGlowAngle);

		} else if (selectionGlowPosition == 2) {

			selectionGlowAngle = selectionGlowRotation;
			selectionGlowAngle.z = -90;
			selectionGlow.GetComponent<RectTransform> ().rotation = Quaternion.Euler (selectionGlowAngle);

		} else if (selectionGlowPosition == 3) {
			
			selectionGlowAngle = selectionGlowRotation;
			selectionGlowAngle.z = 0;
			selectionGlow.GetComponent<RectTransform> ().rotation = Quaternion.Euler (selectionGlowAngle);
			
		} else if (selectionGlowPosition == 4) {

			selectionGlowAngle = selectionGlowRotation;
			selectionGlowAngle.z = 90;
			selectionGlow.GetComponent<RectTransform> ().rotation = Quaternion.Euler (selectionGlowAngle);

		}
	}
}
