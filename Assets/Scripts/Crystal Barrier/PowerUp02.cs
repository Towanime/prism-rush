using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp02 : MonoBehaviour {

	HealthCasters hd;
	public float invincibleTime = 1.0f;

	void Start()
	{
		StartCoroutine(NoDamage());
	}


	public void OnCollisionEnter (Collision other) 
	{
		if (other.gameObject.tag == "Player")
		{ 
			hd = other.gameObject.GetComponent<HealthCasters>();
			StartCoroutine(NoDamage());
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	IEnumerator NoDamage () 
	{
		hd.enabled = false;
		invincibleTime -= Time.deltaTime;
		Debug.Log ("Health Disabled " + hd.currentHealth);
		yield return new WaitForSeconds(2);
		hd.enabled = true;
		Debug.Log ("Health Enabled " + hd.currentHealth);
		Destroy(this);

	}
}
