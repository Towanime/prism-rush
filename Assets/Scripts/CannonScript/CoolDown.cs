using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour {

	float Speed = 10f;
	float DefaultSpeedBonus = 10f;
	float DefaultPowerUpDuration = 5f;
	float DefaultPowerUpCooldown = 10f;
	bool PowerUpIsActivable = true;

	IEnumerator SpeedPowerUp(float bonus, float bonusDuration, float cooldown)
	{
		// Lock the PowerUp
		PowerUpIsActivable = false;

		// Activate the speed bonus
		Speed += bonus;

		// Let it last for bonusDuration seconds
		yield return new WaitForSeconds(bonusDuration);

		// Remove the speed bonus
		Speed -= bonus;

		// Start cooldown
		yield return new WaitForSeconds(cooldown);
		// After cooldown is over, unlock the PowerUp
		PowerUpIsActivable = true;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("PowerUp") && PowerUpIsActivable)
		{
			StartCoroutine(SpeedPowerUp(DefaultSpeedBonus, DefaultPowerUpDuration, DefaultPowerUpCooldown));
		}
	}
}
