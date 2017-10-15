using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Applies an explosion force to all nearby rigidbodies
public class explosionRadius : MonoBehaviour {

	public GameObject bomb;
	//public GameObject deathParticles;
	public float radius = 5.0F;
	public float power = 10.0F;
	public float upforce = 1.0f;


	void FixedUpdate()
	{ 
		if (bomb == enabled) 
		{
			Invoke( "Detonate" ,5);
		}
	}
		void Detonate()
		{
			Vector3 explosionPos = bomb.transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
			foreach (Collider hit in colliders)
			{
				Rigidbody rb = hit.GetComponent<Rigidbody>();

				if (rb != null)
				rb.AddExplosionForce(power, explosionPos, radius, upforce, ForceMode.Impulse);
				//Instantiate (deathParticles, transform.position, Quaternion.Euler (1000, 0, 0));
			}
		}
}
