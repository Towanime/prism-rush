using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingPrismParty : MonoBehaviour {

	public float chargePower;
	public ChargeBar chargeBar;
    public GameObject prismParty;

	public void OnEnemyDamage()
	{
        if (prismParty.activeInHierarchy == false)
        {
            chargeBar.slider.value += chargePower;
        }
	}
}
