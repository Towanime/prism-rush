using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Tooltip("Initial score points for this entity.")]
    public int initialScore;
    [Tooltip("Current score points for this entity.")]
    public int currentScore;
    [Tooltip("True to make this entity ignore any damage.")]
    public bool ignoreDamage = false;
    [Tooltip("Time that the player will stay immune from attacks but able to control the character.")]
    public float timeImmune;
    [Tooltip("Time that the player will stay immune from attacks and unable to control the character.")]
    public float timeStunned;
    [Tooltip("Time in seconds before the rendering is switched between on/off when flickering.")]
    public float timePerFlick;
    [Tooltip("Enable flickering when immune?")]
    public bool flickerEnabled;
    // render and knockback stuff
    [Tooltip("Renderers that will be enabled/disabled when flickering.")]
    public List<Renderer> renderersForFlicker;
    // flickering variables
	public GameObject gameoverScreen;

    private bool renderingEnabled;
    private float elapsedKnockbackTime;
    private float elapsedInvulnerableTime;
    private float elapsedFickerTime;
    private bool onKnockback;
    // last chance
    private bool onLastChance;

    void Start()
    {
        currentScore = initialScore;
    }

    void Update()
    {
        if (onKnockback)
        {
            bool finished = UpdateKnockback();
            UpdateInvulnerable();
            if (finished)
            {
                onKnockback = false;
                ignoreDamage = false;
            }
        }
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
        BeginKnockback(origin);
        BeginInvulnerable();
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
        // if it's not on last chance give it one point
        if (!onLastChance && (currentScore == 0 || currentScore == 1))
        {
            currentScore = 1;
            onLastChance = true;
        }        
    }

    /// <summary>
    /// Called upon healh reaching a number equal or less than 0.
    /// </summary>
    protected virtual void OnDeath()
    {
		gameoverScreen.SetActive (true);

        //Destroy(gameObject);
    }

    /// <summary>
    /// Restores current health and makes it equal to initial health.
    /// </summary>
    public virtual void Refresh()
    {
        currentScore = initialScore;
    }

    //////
    public void BeginKnockback(GameObject origin)
    {
        onKnockback = true;
        ignoreDamage = true;
        elapsedKnockbackTime = 0;
    }

    public bool UpdateKnockback()
    {
        elapsedKnockbackTime += Time.deltaTime;
        return elapsedKnockbackTime >= timeStunned;
    }

    public void BeginInvulnerable()
    {
        elapsedInvulnerableTime = 0;
        elapsedFickerTime = 0;
        renderingEnabled = false;
        if (flickerEnabled)
        {
            EnableRendering(renderingEnabled);
        }
    }

    public bool UpdateInvulnerable()
    {
        if (flickerEnabled)
        {
            UpdateFlicker();
        }
        elapsedInvulnerableTime += Time.deltaTime;
        if (elapsedInvulnerableTime >= timeImmune)
        {
            EnableRendering(true);
            return true;
        }
        return false;
    }

    private void UpdateFlicker()
    {
        elapsedFickerTime += Time.deltaTime;
        if (elapsedFickerTime >= timePerFlick)
        {
            elapsedFickerTime = 0;
            renderingEnabled = !renderingEnabled;
            EnableRendering(renderingEnabled);
        }
    }

    private void EnableRendering(bool enabled)
    {
        foreach (Renderer renderer in renderersForFlicker)
        {
            renderer.enabled = enabled;
        }
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
        set {
            currentScore = value;
            if (onLastChance && value > 0)
            {
                onLastChance = false;
            }
        }
    }
}
