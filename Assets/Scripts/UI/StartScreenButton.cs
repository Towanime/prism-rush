using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class StartScreenButton : MonoBehaviour, IPointerDownHandler // required interface when using the OnPointerDown method.
{

	public StartScreenTransition startScreenTransition;

	public GameObject blackBackground;

	public void OnPointerDown (PointerEventData eventData) 
	{
		startScreenTransition.transition = true;
	}

	public void animEnd(){
		blackBackground.GetComponent<Animator> ().enabled = true;
	}
}
