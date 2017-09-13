using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismMagicEmitter : MonoBehaviour {
    [Tooltip("Object from where the bullets will spawn. Recomended an empty object with no collisions.")]
    public Transform emitter;
    [Tooltip("Delay between bullets.")]
    public float fireRate = 0.05f;
    [Tooltip("Optional bullet speed, this will override the speed on the bullet prefab if overrideBulletSpeed is set to true.")]
    public float bulletSpeed = 15f;
    [Tooltip("If true it will override the bullet's prefab speed with the one on this component.")]
    public bool overrideBulletSpeed = true;
    public bool isEnabled = true;

    private PlayerController playerController;
    // cooldown vars
    private float currentCooldown;
    private bool wait;

    // Use this for initialization
    void Start () {
        playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (wait)
        {
            currentCooldown += Time.fixedDeltaTime;
            // turn off wait if the time is up
            if (currentCooldown >= fireRate)
            {
                wait = false;
            }
        }
    }

    public bool Fire ()
    {
        if (!isEnabled) return false;
        if (!wait)
        {
            GameObject bullet = BulletPool.instance.GetObject();
            // clear bullet trail
            //bullet.GetComponent<TrailRenderer>().Clear();
            bullet.transform.position = emitter.position;
            //bullet.transform.LookAt(playerController.lookPoint);
            Bullet component = bullet.GetComponent<Bullet>();
            component.SetDirection(playerController.lookPoint.normalized);
            ///component.SetDirection(GetBulletDirection(aimingAngle));
            bullet.SetActive(true);
            return true;
        }
        return false;
    }
}
