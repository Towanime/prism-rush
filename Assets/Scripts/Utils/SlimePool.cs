using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePool : BasicPool
{
    public SlimeStatDefinition[] slimePhases;
    public int defaultStatPhaseIndex = 2;
    public static SlimePool instance;

    void Awake()
    {
        instance = this;
    }

    public override GameObject GetObject()
    {
        GameObject slime = base.GetObject();
        // set stats for new slime
        SetPhaseStats(defaultStatPhaseIndex, slime);
        return slime;
    }


    public GameObject GetObjectByPhase(int index)
    {
        GameObject slime = base.GetObject();
        // get health component and set the default
        SetPhaseStats(index, slime);
        return slime;
    }

    // apply slime stats here!
    public void SetPhaseStats(int index, GameObject slime)
    {
        // get phase by index
        SlimeStatDefinition phase = slimePhases[index];
        SlimeHealth sh = slime.GetComponent<SlimeHealth>();
        sh.PhaseIndex = index;
        sh.PhaseDefinition = phase;
        // hp
        sh.initialHealth = phase.hp;
        sh.Refresh();
        // apply scale
        slime.transform.localScale = phase.scale;
        // speed
        slime.GetComponent<BasicFollowMovement>().UpdateSpeed(phase.speed);
    }
}