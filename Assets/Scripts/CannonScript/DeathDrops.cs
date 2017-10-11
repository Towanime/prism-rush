using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDrops : MonoBehaviour {

	public GameObject[] Items;
	public int CastersHealth = 10;

	// Use this for initialization
	void Start () {

	}

	void ApplyDamage (int TheDamage) 
	{
		CastersHealth -= TheDamage;
	}

	// Update is called once per frame
	void Update ()
	{
		if(CastersHealth <= 0)
		{
			Death();
		}
	}

	void Death()
	{
		Destroy(gameObject, 2);
		Instantiate(Items[Random.Range(0, Items.Length)], transform.position, Quaternion.identity);
	}
}
