using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlammerHealth : Health {

	public GameObject prismDrop;

    /// <summary>
    /// Called upon healh reaching a number equal or less than 0.
    /// </summary>
    protected override void OnDeath()
    {
		Instantiate (prismDrop, this.gameObject.transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
}
