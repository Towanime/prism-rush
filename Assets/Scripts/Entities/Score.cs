using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Tooltip("Initial score points for this entity.")]
    public int initialScore;
    [Tooltip("True to make this entity ignore any damage.")]
    public bool ignoreDamage = false;
    // current hp
    public int currentScore;

    void Start()
    {
        currentScore = initialScore;
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
        if (currentScore <= 0)
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
        currentScore = (int) Mathf.Max(currentScore - damage, 0);
    }

    /// <summary>
    /// Called upon healh reaching a number equal or less than 0.
    /// </summary>
    protected virtual void OnDeath()
    {
        Debug.Log("Player Dead");
        //Destroy(gameObject);
    }

    /// <summary>
    /// Restores current health and makes it equal to initial health.
    /// </summary>
    public virtual void Refresh()
    {
        currentScore = initialScore;
    }
   
    /// <summary>
    /// Returns or sets the initial health of this entity.
    /// </summary>
    public int InitialScore
    {
        get { return initialScore; }
        set { initialScore = value; }
    }

    /// <summary>
    /// Returns or sets the current heatlh for this entity.
    /// </summary>
    public int CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }
}
