using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [Tooltip("Game object that will be moved, contains avatar and other children.")]
    public GameObject root;
    [Tooltip("Player avatar model, used to know the rotation.")]
    public GameObject avatar;
    [Tooltip("Distance in unity unit to travel.")]
    public float distance;
    [Tooltip("Movement speed.")]
    public float speed = 5;

    // private variables
    private Vector3 target;
    private bool started;
    
	public void Begin () {
        target = avatar.transform.forward;
        target.x *= distance;
        target.z *= distance;
        started = true;
    }

    void Update()
    {
       if (started)
        {
            float step = speed * Time.deltaTime;
            root.transform.position = Vector3.MoveTowards(root.transform.position, target, step);
            // check if target reached
            if(root.transform.position == target)
            {
                started = false;
            }
        }
    }

    public bool Finished
    {
        get { return !started; }
    }
}
