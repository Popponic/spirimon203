using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirimon
{
    SpirimonBase sBase;
    int level;

    public int HP { get; set; }

    public List<Move> Moves { get; set; }

    Spirimon(SpirimonBase sb, int lvl)
    {
        sBase = sb;
        level = lvl;
        // HP = sBase.MaxHp; :: UNCOMMENT WHEN MAX UP FORMULA IS CREATED

        Moves = new List<Move>();
        foreach(var move in sBase.LearnableMoves)
        {
            if(move.Level <= level)
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
    public int Attack
    {
        get { return Mathf.FloorToInt((2 * sBase.Atk * level / 100) + 5); }
    }

    // ADD MORE HERE
}
