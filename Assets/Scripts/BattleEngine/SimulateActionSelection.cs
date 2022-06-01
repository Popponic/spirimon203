using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateActionSelection : MonoBehaviour
{
    [SerializeField] int actionNum;
    [SerializeField] BattleSystem battleSystem;

    public void SimActionSelect()
    {
        battleSystem.currentAction = actionNum;
    }

}
