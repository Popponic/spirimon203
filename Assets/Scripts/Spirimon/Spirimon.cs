using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirimon
{
    public SpirimonBase Base { get; set; }
    public int Level { get; set; }

    public int HP { get; set; }

    public List<Move> Moves { get; set; }

    public Spirimon(SpirimonBase sb, int lvl)
    {
        Base = sb;
        Level = lvl;
        HP = MaxHP;

        Moves = new List<Move>();
        foreach(var move in Base.LearnableMoves)
        {
            if(move.Level <= Level)
            {
                Moves.Add(new Move(move.Base));
            }

            if(Moves.Count >= 4)
            {
                break;
            }
        }
    }


    // Damage formulas
    // We are leaving each stat with its own calc property, for easy modification
    public int Attack
    {
        get { return Mathf.FloorToInt((2 * Base.Atk * Level / 100) + 5); }
    }

    public int Defense
    {
        get { return Mathf.FloorToInt((2 * Base.Def * Level / 100) + 5); }
    }

    public int Speed
    {
        get { return Mathf.FloorToInt((2 * Base.Spe * Level / 100) + 5); }
    }

    public int MaxHP
    {
        get { return Mathf.FloorToInt((2 * Base.MaxHp * Level / 100) + 10); }
    }

    // ADD MORE HERE
}
