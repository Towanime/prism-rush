using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject ExplosionPrefab;
	public GameObject projectilePrefab;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire1"))
		{
			GameObject hitPlayer;
			//Rigidbody hitPlayer;
			hitPlayer = Instantiate(projectilePrefab, spawnPoint.transform.position, transform.rotation) as GameObject;
			//hitPlayer.GetComponent<FollowArc> ().SetStartPosition (spawnPoint.transform.position);
			hitPlayer.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 100);
			//            Physics.IgnoreCollision ( projectilePrefab.collider, transform.root.collider );


		}
		}



	/*	for(var i =0; i < Input.touchCount; ++i)
		{
			if(Input.GetTouch(i).phase == TouchPhase.Began )
			{
				Rigidbody clone;
				clone = Instantiate(projectilePrefab, transform.position, transform.rotation) as Rigidbody;
				clone.velocity = transform.TransformDirection(Vector3.forward * 200);
				//            Physics.IgnoreCollision ( projectilePrefab.collider, transform.root.collider );


			}
		}*/



	}
