using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchHazard : Hazard
{
    public void OnCollisionEnter(Collision collision)
    {
        Score scoreComponent = collision.gameObject.GetComponent<Score>();
        if (collision.gameObject.name == "Player" && scoreComponent)
        {
            scoreComponent.OnDamage(collision.gameObject, damage);
        }

    }
    
}