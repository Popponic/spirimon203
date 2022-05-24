using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    MoveBase Base { get; set; }

    public Move(MoveBase sBase)
    {
        Base = sBase;
    }
}
