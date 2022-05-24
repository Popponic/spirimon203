using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirimon
{
    SpirimonBase sBase;
    int level;

    Spirimon(SpirimonBase sb, int lvl)
    {
        sBase = sb;
        level = lvl;
    }

    public int Attack
    {
        get { return Mathf.FloorToInt((2 * sBase.Atk * level / 100) + 5); }
    }

}
