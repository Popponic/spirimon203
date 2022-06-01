using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateMoveSelection : MonoBehaviour
{
    [SerializeField] int moveNum;
    [SerializeField] BattleSystem battleSystem;

    public void SimMoveSelect()
    {
        battleSystem.currentMove = moveNum;
    }

}
