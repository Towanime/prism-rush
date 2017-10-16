using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingPrismParty : MonoBehaviour {

	public float chargePower;
	public ChargeBar chargeBar;

	public void OnEnemyDamage()
	{
		chargeBar.slider.value += chargePower;
	}
}
