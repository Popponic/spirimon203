using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Spirimon/Create new ability")]
public class AbilityBase : ScriptableObject
{
    [SerializeField] string name;
    [TextArea][SerializeField] string description;
    [SerializeField] AbilityType type;
    [SerializeField] float modifier;

    public float Modifier
    {
        get { return modifier; }
    }

    public string Name
    {
        get { return name; }
    }

    public AbilityType Type
    {
        get { return type; }
    }

}

public enum AbilityType
{
    None,
    Rolling,
    Kicking,
    Punching,
    Clawing,
    Atk_Boost,
    Def_Boost,
    Spd_Boost
}
