using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spirimon", menuName = "Spirimon/Create new Spirimon")]
public class SpirimonBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string desc;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] SpirimonType type1;
    [SerializeField] SpirimonType type2;

    // Base Spirimon stats
    [SerializeField] int hp;
    [SerializeField] int atk;
    [SerializeField] int def;
    [SerializeField] int spe;
    [SerializeField] int sp;

    [SerializeField] List<LearnableMove> learnableMoves;

    public string Name
    {
        get { return name; }
    }

    public string Desc
    {
        get { return desc; }
    }

    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }

    public Sprite BackSprite
    {
        get { return backSprite; }
    }

    public SpirimonType Type1
    {
        get { return type1; }
    }

    public SpirimonType Type2
    {
        get { return type2; }
    }

    public int Hp
    {
        get { return hp; }
    }

    public int Atk
    {
        get { return atk; }
    }

    public int Def
    {
        get { return def; }
    }

    public int Spe
    {
        get { return spe; }
    }

    public int Sp
    {
        get { return sp; }
    }

    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }

}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base
    {
        get { return moveBase; }
    }

    public int Level
    {
        get { return level; }
    }

}

public enum SpirimonType
{
    None,
    Regular,
    Water,
    Fire,
    Nature,
    Electric,
    Earth,
    Wind,
    Might,
    Frost,
    Metal,
    Dark,
    Atomic,
    Light
}