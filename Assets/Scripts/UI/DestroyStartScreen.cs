using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStartScreen : MonoBehaviour {

	public GameObject startScreen;

	public void boom(){
		
		Destroy(startScreen);
	}
}
