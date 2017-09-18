using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonShot : MonoBehaviour {
    [Tooltip("Object from where the bullets will spawn. Recomended an empty object with no collisions on the \"Player\" layer.")]
    public Transform emitter;
    [Tooltip("Amount of bullets to shoot in a second, this will be adjusted depending on the level.")]
    public int bulletsPerSecond = 2;
    [Tooltip("Optional bullet speed, this will override the speed on the bullet prefab if overrideBulletSpeed is set to true.")]
    public float bulletSpeed = 15f;
    [Tooltip("If true it will override the bullet's prefab speed with the one on this component.")]
    public bool overrideBulletSpeed = true;
    public bool isEnabled = true;

    private PlayerController playerController;
    // cooldown vars
    private float fireRate;
    private float currentCooldown;
    private bool wait;

    // Use this for initialization
    void Start () {
        playerController = GetComponent<PlayerController>();
        fireRate = 1.0f / bulletsPerSecond;
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
                currentCooldown = 0;
            }
        }
    }

    public bool Fire ()
    {
        if (!isEnabled) return false;
        if (!wait)
        {
            wait = true;
            GameObject bullet = BulletPool.instance.GetObject();
            // clear bullet trail
            bullet.GetComponent<TrailRenderer>().Clear();
            // new position and rotation
            bullet.transform.position = emitter.position;
            bullet.transform.rotation = emitter.rotation;
            // change speed if needed
            if (overrideBulletSpeed)
            {
                Bullet component = bullet.GetComponent<Bullet>();
                component.speed = bulletSpeed;
            }
            // add to scene
            bullet.SetActive(true);
            return true;
        }
        return false;
    }
}
