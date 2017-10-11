using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathCooldown : MonoBehaviour {


	bool dead = false;
	public int value = 1;
	//public int yay = 1;
	public float deathCooldown = 5.0f; // time in seconds to wait
	public float startTime;

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "cup")
		{
			//ScorePoints.score += value;
		}
		else if (col.gameObject.tag == "Death")
		{
			dead = true;
			startTime = Time.time;
		}
	}

	void Update()
	{
		if (dead && (Time.time >= startTime + deathCooldown || Input.GetMouseButtonDown(0)))
			{
				SceneManager.LoadScene("Scene");
			}
		}
}
