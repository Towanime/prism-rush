using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class AimingStateMachine : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerController playerController;
    //public GameObject crosshair;

    private StateMachine<AimStates> fsm;

    void Default_Enter()
    {
        Cursor.lockState = CursorLockMode.Confined;
//        Cursor.visible = false;
    }

    void Default_Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var groundPlane = new Plane(Vector3.up, Vector3.up);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            var point = ray.GetPoint(rayDistance);
            playerController.LookAt(point);
            //crosshair.transform.position = point;
        }
    }

    void Default_FixedUpdate()
    {
    }

    void Disabled_Enter()
    {
    }

    public StateMachine<AimStates> StateMachine
    {
        get
        {
            if (fsm == null)
            {
                fsm = StateMachine<AimStates>.Initialize(this, AimStates.Default);
            }
            return fsm;
        }
    }
}
