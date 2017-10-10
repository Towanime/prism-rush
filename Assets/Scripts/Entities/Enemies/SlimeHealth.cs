using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : Health {

    private SlimeStatDefinition currentDefinition;
    private int phaseIndex = -1;

    void Start()
    {
        currentHealth = initialHealth;
        // in case of drag and drop slimes on unity
        if (phaseIndex == -1)
        {
            SlimePool.instance.SetPhaseStats(SlimePool.instance.slimePhases.Length - 1, gameObject);
            //currentDefinition = SlimePool.instance.slimePhases[SlimePool.instance.slimePhases.Length-1];
            //phaseIndex = SlimePool.instance.slimePhases.Length - 1;
        }
    }

    /// <summary>
    /// Called upon healh reaching a number equal or less than 0.
    /// </summary>
    protected override void OnDeath()
    {
        for (int i = 0; i < currentDefinition.splitInto; i++)
        {
            GameObject slime = SlimePool.instance.GetObjectByPhase(phaseIndex - 1);
            Vector2 randomPoint = Random.insideUnitCircle * Random.Range(2, 3);
            Vector3 spawnPosition = transform.position;
            spawnPosition.x += randomPoint.x;
            spawnPosition.z += randomPoint.y;
            // hack to stay close to the navmesh and agent doesnt fail
            spawnPosition.y = -0.9f;
            slime.transform.position = spawnPosition;
            slime.SetActive(true);
        }
        gameObject.SetActive(false);
    }

    public int PhaseIndex
    {
        set { phaseIndex = value; }
        get { return phaseIndex; }
    }

    public SlimeStatDefinition PhaseDefinition
    {
        set { currentDefinition = value; }
        get { return currentDefinition; }
    }
}
