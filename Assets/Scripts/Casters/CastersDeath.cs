using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastersDeath : Health {

	public int currentHealth;

	private Animator animator;


	public GameObject deathParticles;
	public bool drop;
	public GameObject theDrop;




	void Update()
	{
		if(currentHealth <=0)
		{

			OnDeath ();

		}

	}

	protected override void OnDeath()
	{
		animator.SetTrigger("isDead");
		if(drop) Instantiate (theDrop,transform.position, transform.rotation);
		Instantiate (deathParticles, transform.position, Quaternion.Euler (1000, 0, 0));
		transform.position = new Vector3(Random.Range(100.0F, 100.0F), 0.03f, Random.Range(100.0F, 100.0F));
	}

}
