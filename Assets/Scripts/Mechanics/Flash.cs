using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [Tooltip("Player avatar model, used to know the rotation.")]
    public GameObject avatar;
    [Tooltip("Damage done to enemies after going through them.")]
    public float hazardDamage = 10;
    [Tooltip("Distance in unity unit to travel.")]
    public float distance = 8;
    [Tooltip("Adjust depending on the scale and center of the avatar, will dictate how easily if the flash collides with something.")]
    public float collisionRadius = 0.3f;
    [Tooltip("Movement speed.")]
    public float speed = 25;
    [Tooltip("Cooldown for this ability.")]
    public float cooldown = 0.5f;
    [Tooltip("Which layers will ignore during the flash.")]
    public LayerMask flashModeIgnoreLayers;
    [Tooltip("Object with the trigger used to hurt enemies while in flash mode.")]
    public GameObject flashTrigger;
    // private variables
    private FlashHazard flashHazard;
    private int defaultLayer;
    private Collider avatarCollider;
    private Vector3 target;
    private bool started;
    // cooldown vars
    private float currentCooldown;
    private bool wait;

    void Start()
    {
        avatarCollider = GetComponent<Collider>();
        flashHazard = flashTrigger.AddComponent(typeof(FlashHazard)) as FlashHazard;
        flashHazard.damage = hazardDamage;
    }
    
    void FixedUpdate()
    {
        if (wait)
        {
            currentCooldown += Time.fixedDeltaTime;
            // turn off wait if the time is up
            if (currentCooldown >= cooldown)
            {
                wait = false;
                currentCooldown = 0;
            }
        }
        else
        {
            if (started)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target, step);
                // check if target reached
                if (transform.position == target)
                {
                    End();
                }
            }
        }
    }

    /// <summary>
    /// Initiate flash variables and leave them ready for the next update.
    /// </summary>
    public void Begin()
    {
        if (started) return;
        float targetDistance = distance;
        // check if the whole distance is traversable
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, collisionRadius, avatar.transform.forward, out hit, targetDistance, ~flashModeIgnoreLayers.value))
        {
            targetDistance = hit.distance;
            Debug.Log("Flash distance: " + targetDistance);
        }
        // calculate new target
        target = avatar.transform.forward;
        target.x *= targetDistance;
        target.z *= targetDistance;
        target += transform.position;
        started = true;
        // enable flash trigger to damage enemies
        flashTrigger.SetActive(true);
        // change collider's layer to ignore enemies
        defaultLayer = gameObject.layer;
        gameObject.layer = LayerMask.NameToLayer("Player Flash Mode");

    }

    /// <summary>
    /// Finished or cancels flash mechanic. 
    /// </summary>
    private void End()
    {
        wait = true;
        started = false;
        flashTrigger.SetActive(false);
        gameObject.layer = defaultLayer;
    }

    public bool Finished
    {
        get { return !started; }
    }
}
