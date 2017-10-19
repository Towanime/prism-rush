using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchHazard : Hazard
{
    private bool collided;

    public void OnCollisionEnter(Collision collision)
    {
        Score scoreComponent = collision.gameObject.GetComponent<Score>();
        if (collision.gameObject.name == "Player" && scoreComponent)
        {
            scoreComponent.OnDamage(collision.gameObject, damage);
            collided = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        collided = false;
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collided)
        {
            Score scoreComponent = collision.gameObject.GetComponent<Score>();
            if (collision.gameObject.name == "Player" && scoreComponent)
            {
                scoreComponent.OnDamage(collision.gameObject, damage);
            }
        }
    }
}