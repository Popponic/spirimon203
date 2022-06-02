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
    [SerializeField] int maxHp;
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

    public int MaxHp
    {
        get { return maxHp; }
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
} // 14 TYPES

public class TypeChart
{
    static float[][] chart =
    {
        /*REG*/ new float[]{
                    /*REG*/1f,/*WAT*/1f,/*FIR*/1f,/*NAT*/1f,/*ELC*/1f,/*EAR*/0.5f,/*WND*/1f, 
                    /*MIG*/1f,/*FRS*/1f,/*MTL*/0.5f,/*DRK*/1f,/*ATM*/0.5f,/*LGT*/1f},
        /*WAT*/ new float[]{
                    /*REG*/1f,/*WAT*/0.5f,/*FIR*/2f,/*NAT*/0.5f,/*ELC*/1f,/*EAR*/2f,/*WND*/1f, 
                    /*MIG*/1f,/*FRS*/0.5f,/*MTL*/1f,/*DRK*/1f,/*ATM*/2f,/*LGT*/1f},
        /*FIR*/ new float[]{
                    /*REG*/1f,/*WAT*/0.5f,/*FIR*/0.5f,/*NAT*/2f,/*ELC*/1f,/*EAR*/0.5f,/*WND*/1f, 
                    /*MIG*/1f,/*FRS*/2f,/*MTL*/2f,/*DRK*/1f,/*ATM*/1f,/*LGT*/1f},
        /*NAT*/ new float[]{
                    /*REG*/1f,/*WAT*/2f,/*FIR*/0.5f,/*NAT*/0.5f,/*ELC*/1f,/*EAR*/2f,/*WND*/0.5f, 
                    /*MIG*/1f,/*FRS*/0.5f,/*MTL*/0.5f,/*DRK*/1f,/*ATM*/0.5f,/*LGT*/0.5f},
        /*ELC*/ new float[]{
                    /*REG*/1f,/*WAT*/2f,/*FIR*/1f,/*NAT*/0.5f,/*ELC*/0.5f,/*EAR*/0f,/*WND*/2f, 
                    /*MIG*/1f,/*FRS*/0.5f,/*MTL*/1f,/*DRK*/1f,/*ATM*/1f,/*LGT*/1f},
        /*EAR*/ new float[]{
                    /*REG*/1f,/*WAT*/1f,/*FIR*/2f,/*NAT*/0.5f,/*ELC*/2f,/*EAR*/0.5f,/*WND*/0.5f, 
                    /*MIG*/1f,/*FRS*/1f,/*MTL*/2f,/*DRK*/1f,/*ATM*/2f,/*LGT*/1f},
        /*WND*/ new float[]{
                    /*REG*/1f,/*WAT*/1f,/*FIR*/2f,/*NAT*/2f,/*ELC*/0.5f,/*EAR*/1f,/*WND*/0.5f, 
                    /*MIG*/2f,/*FRS*/1f,/*MTL*/0.5f,/*DRK*/1f,/*ATM*/0f,/*LGT*/1f},
        /*MIG*/ new float[]{
                    /*REG*/2f,/*WAT*/1f,/*FIR*/1f,/*NAT*/1f,/*ELC*/1f,/*EAR*/1f,/*WND*/0.5f, 
                    /*MIG*/1f,/*FRS*/2f,/*MTL*/2f,/*DRK*/1f,/*ATM*/0.5f,/*LGT*/1f},
        /*FRS*/ new float[]{
                    /*REG*/1f,/*WAT*/0.5f,/*FIR*/0.5f,/*NAT*/2f,/*ELC*/1f,/*EAR*/2f,/*WND*/2f, 
                    /*MIG*/1f,/*FRS*/0.5f,/*MTL*/0.5f,/*DRK*/1f,/*ATM*/1f,/*LGT*/1f},
        /*MTL*/ new float[]{
                    /*REG*/1f,/*WAT*/0.5f,/*FIR*/0.5f,/*NAT*/1f,/*ELC*/1f,/*EAR*/2f,/*WND*/1f, 
                    /*MIG*/0.5f,/*FRS*/2f,/*MTL*/0.5f,/*DRK*/1f,/*ATM*/1f,/*LGT*/1f},
        /*DRK*/ new float[]{
                    /*REG*/1f,/*WAT*/1f,/*FIR*/1f,/*NAT*/1f,/*ELC*/1f,/*EAR*/1f,/*WND*/1f, 
                    /*MIG*/0.5f,/*FRS*/1f,/*MTL*/1f,/*DRK*/0.5f,/*ATM*/1f,/*LGT*/2f},
        /*ATM*/ new float[]{
                    /*REG*/1f,/*WAT*/0.5f,/*FIR*/1f,/*NAT*/2f,/*ELC*/1f,/*EAR*/0.5f,/*WND*/1f, 
                    /*MIG*/2f,/*FRS*/1f,/*MTL*/0f,/*DRK*/0.5f,/*ATM*/2f,/*LGT*/0.5f},
        /*LGT*/ new float[]{
                    /*REG*/1f,/*WAT*/1f,/*FIR*/1f,/*NAT*/0.5f,/*ELC*/0.5f,/*EAR*/1f,/*WND*/1f, 
                    /*MIG*/2f,/*FRS*/1f,/*MTL*/1f,/*DRK*/2f,/*ATM*/1f,/*LGT*/0.5f},
    };

    public static float GetEffectiveness(SpirimonType attackType, SpirimonType defenseType)
    {
        if (attackType == SpirimonType.None || defenseType == SpirimonType.None)
            return 1;

        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        return chart[row][col];
    }
}