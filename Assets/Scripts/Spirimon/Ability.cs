using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public AbilityBase Base { get; set; }

    public Ability(AbilityBase aBase)
    {
        Base = aBase;
    }
}
