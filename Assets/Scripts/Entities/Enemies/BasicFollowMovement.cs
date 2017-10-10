using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicFollowMovement : MonoBehaviour
{
    [Tooltip("NavMeshAgent to manipulate.")]
    public NavMeshAgent agent;
    // player object to follow
    private GameObject target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        agent.destination = target.transform.position;
    }
}
