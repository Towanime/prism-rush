using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCasters : MonoBehaviour {

	private CastersDeath cd;
	public int maxHealth = 10;
	public int currentHealth;


	void Start()
	{
		cd = GetComponent<CastersDeath> ();
		currentHealth = maxHealth;
	}

	public void Update()
	{
		if (currentHealth < 0) 
		{
			currentHealth = 0;
			cd.OnDeath();
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

	}

}
