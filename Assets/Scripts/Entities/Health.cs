using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Tooltip("Max health points for this entity.")]
    public float initialHealth;
    [Tooltip("True to make this entity ignore any damage.")]
    public bool ignoreDamage = false;
    // current hp
    protected float currentHealth;

    void Start()
    {
        currentHealth = initialHealth;
    }

    /// <summary>
    /// Entity takes specified damage and may trigger OnDeath method if necessary.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="damage"></param>
    /// <returns></returns>
    public virtual bool OnDamage(GameObject origin, float damage)
    {
        if (ignoreDamage) return false;
        ModifyCurrentLife(damage);
        if (currentHealth <= 0)
        {
            OnDeath();
        }
        return true;
    }

    /// <summary>
    /// Substract damage from the current health value.
    /// </summary>
    /// <param name="damage"></param>
    protected virtual void ModifyCurrentLife(float damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
    }

    /// <summary>
    /// Called upon healh reaching a number equal or less than 0.
    /// </summary>
    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Restores current health and makes it equal to initial health.
    /// </summary>
    public virtual void Refresh()
    {
        currentHealth = initialHealth;
    }

    /// <summary>
    /// Returns or sets the initial health of this entity.
    /// </summary>
    public float InitialHealth
    {
        get { return initialHealth; }
        set { initialHealth = value; }
    }

    /// <summary>
    /// Returns or sets the current heatlh for this entity.
    /// </summary>
    public float CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
}
