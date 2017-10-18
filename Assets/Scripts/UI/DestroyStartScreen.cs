using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStartScreen : MonoBehaviour {

	public GameObject startScreen;
	public GameObject gameoverScreen;
	public GameObject gameoverScreenPrefab;
	public GameObject canvas;

	public void boom(){
		Instantiate (gameoverScreenPrefab);
		gameoverScreen = GameObject.FindGameObjectWithTag ("GameoverScreen");
		canvas = GameObject.Find ("Canvas");
		gameoverScreen.transform.SetParent (canvas.transform);
		gameoverScreen.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
		Destroy(startScreen);
	}
}
