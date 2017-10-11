using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowArc : MonoBehaviour {

	Vector3 startPos; // = new Vector3(0, 1, 1.40f);
	Vector3 endPos = new Vector3(0, 0, 10);
	float height = 4f;
	bool startThrow = false;
	float incrementor = 0;

	void Start(){
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (startThrow)
		{
			incrementor += 0.04f;
			Vector3 currentPos = Vector3.Lerp(startPos, endPos, incrementor);
			currentPos.y += height * Mathf.Sin(Mathf.Clamp01(incrementor) * Mathf.PI);
			transform.position = currentPos;

		}

			startThrow = true;

	}

	public void SetStartPosition(Vector3 pos)
	{
		startPos = pos;
	}
}
