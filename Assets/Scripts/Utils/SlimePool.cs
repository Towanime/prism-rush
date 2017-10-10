using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePool : BasicPool
{
    public SlimeStatDefinition[] slimePhases;
    public int defaultStatPhaseIndex = 3;
    public static SlimePool instance;

    void Awake()
    {
        instance = this;
    }

    public override GameObject GetObject()
    {
        GameObject slime = base.GetObject();
        // get health component and set the default
        slime.GetComponent<SlimeHealth>().PhaseIndex = defaultStatPhaseIndex;
        return slime;
    }


    public GameObject GetObjectByPhase(int index)
    {
        GameObject slime = base.GetObject();
        // get health component and set the default
        slime.GetComponent<SlimeHealth>().PhaseIndex = index;
        return slime;
    }

    // apply slime stats here!
}