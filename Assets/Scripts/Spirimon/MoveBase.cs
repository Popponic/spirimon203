using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Spirimon/Create new Move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string desc;

    [SerializeField] SpirimonType type;
    [SerializeField] MoveType moveType;
    [SerializeField] AdditionalType additionalType;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int spCost;

    public string Name
    {
        get { return name; }
    }

    public string Desc
    {
        get { return desc; }
    }

    public SpirimonType Type
    {
        get { return type; }
    }

    public MoveType MoveType
    {
        get { return moveType; }
    }

    public AdditionalType AdditionalType
    {
        get { return additionalType; }
    }

    public int Power
    {
        get { return power; }
    }

    public int Accuracy
    {
        get { return accuracy; }
    }

    public int SpCost
    {
        get { return spCost; }
    }

}

public enum MoveType
{
    None,
    Physical,
    Special,
    Status
}

public enum AdditionalType
{
    None,
    Rolling,
    Kicking,
    Punching,
    Clawing
}