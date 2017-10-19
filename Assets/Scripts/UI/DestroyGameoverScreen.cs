using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyGameoverScreen : MonoBehaviour {

	public GameObject startScreen;
	public GameObject gameoverScreen;
	public GameoverScreenTransition gameoverScreenTransition;

	public void startScreenSpawn(){
		startScreen.SetActive (true);
	}
	public void boom(){
		gameoverScreenTransition.transition = false;
		gameoverScreen.SetActive (false);
		SceneManager.LoadScene( SceneManager.GetActiveScene().name );
	}
}
