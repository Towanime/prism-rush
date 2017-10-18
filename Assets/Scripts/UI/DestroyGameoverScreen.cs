using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameoverScreen : MonoBehaviour {

	public GameObject startScreen;
	public GameObject startScreenPrefab;
	public GameObject gameoverScreen;
	public GameObject screenObject;

	public void startScreenSpawn(){
		Instantiate (startScreenPrefab);
		startScreen = GameObject.FindGameObjectWithTag ("StartScreen");
		screenObject = GameObject.Find ("Screens");
		startScreen.transform.SetParent (screenObject.transform);
		startScreen.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
	}
	public void boom(){
		
		Destroy(gameoverScreen);
	}
}
