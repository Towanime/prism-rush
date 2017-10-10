using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : Health {

    private SlimeStatDefinition currentDefinition;
    private int phaseIndex;

    /// <summary>
    /// Called upon healh reaching a number equal or less than 0.
    /// </summary>
    protected override void OnDeath()
    {
        
    }

    public int PhaseIndex
    {
        set { phaseIndex = value; }
        get { return phaseIndex; }
    }
}
