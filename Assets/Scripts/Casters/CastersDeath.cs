using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastersDeath : MonoBehaviour {

	private HealthCasters HC;

	private Animator animator;


	public GameObject deathParticles;
	public bool drop;
	public GameObject theDrop;

	void Start()
	{
		HC = GetComponent<HealthCasters>();
		animator = GetComponent<Animator> ();
	}


	public void Update()
	{
		if(HC.currentHealth <=0)
		{

			OnDeath ();

		}

	}

	public void OnDeath()
	{
		animator.SetTrigger("isDead");
		drop = true;
		if(drop) Instantiate (theDrop,transform.position, transform.rotation);
		Instantiate (deathParticles, transform.position, Quaternion.Euler (1000, 0, 0));
		transform.position = new Vector3(Random.Range(100.0F, 100.0F), 0.03f, Random.Range(100.0F, 100.0F));
		Destroy (this);
	}

}
