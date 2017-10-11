using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCasters : MonoBehaviour {

	public const int maxHealth = 10;
	public int currentHealth = maxHealth;
	public RectTransform healthBar;

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;

		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	}
}
