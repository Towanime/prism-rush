using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashHazard : MonoBehaviour
{
    /// <summary>
    /// Set during game initialization, will apply to all enemies with health component.
    /// </summary>
    public float damage;

    public void OnTriggerEnter(Collider other)
    {
    }

    public void OnTriggerExit(Collider other)
    {
        // check if the object is damagable
        Health healthComponent = other.GetComponent<Health>();
        if (healthComponent)
        {
            healthComponent.OnDamage(gameObject, damage);
            Debug.Log("Damaged! -" + damage);
        }
    }
}
