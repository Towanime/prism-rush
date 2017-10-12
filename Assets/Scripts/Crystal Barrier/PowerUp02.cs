using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp02 : MonoBehaviour {

	HealthCasters hd;
	public float invincibleTime = 1.0f;
	private MeshRenderer Mrender;

	void Start()
	{
		StartCoroutine(NoDamage());
		Mrender = GetComponent<MeshRenderer> ();
	}


	public void OnCollisionEnter (Collision other) 
	{
		if (other.gameObject.tag == "Player")
		{ 
			hd = other.gameObject.GetComponent<HealthCasters>();
			StartCoroutine(NoDamage());
			GetComponent<MeshRenderer>().enabled = false;
			GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	public IEnumerator NoDamage () 
	{
		hd.enabled = false;
		StartCoroutine(Flicker());
		invincibleTime -= Time.deltaTime;
		Debug.Log ("Health Disabled " + hd.currentHealth);
		yield return new WaitForSeconds(invincibleTime);
		hd.enabled = true;
		Debug.Log ("Health Enabled " + hd.currentHealth);
		Destroy(this);

	}

	private IEnumerator Flicker()
	{
		Mrender.enabled = false;
		yield return new WaitForSeconds(.1f);
		Mrender.enabled = true;
		yield return new WaitForSeconds(.1f);
	}
}
