using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for any component that applies a given damage to a GameObject.
/// </summary>
public class Hazard : MonoBehaviour
{
    [Tooltip("If true, the hazard will do damage to the target. Use this instead of disabling the whole component.")]
    public bool isActive = true;
    [Tooltip("Damage to apply.")]
    public float damage;
    
    /// <summary>
    /// Does damage to the given object only if the component is enabled 
    /// and the object is one of the targets of this component.
    /// </summary>
    /// <param name="obj">Object to apply damage to.</param>
    /// <returns>True if the object received any damage.</returns>
    protected virtual bool DoDamage(GameObject obj)
    {
        if (isActive)
        {
            // maybe do the checks here later
            // check if the object is damagable
            Health healthComponent = obj.GetComponent<Health>();
            if (healthComponent)
            {
                return healthComponent.OnDamage(gameObject, damage);
            }
        }
        return false;
    }
   
}