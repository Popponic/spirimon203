using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleHUD playerHUD;

    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHUD enemyHUD;

    [SerializeField] BattleDialogBox dialogBox;

    private void Start()
    {
        InitBattle();
    }


    public void InitBattle()
    {
        playerUnit.Setup();
        playerHUD.SetData(playerUnit.Spirimon);

        enemyUnit.Setup();
        enemyHUD.SetData(enemyUnit.Spirimon);

        StartCoroutine(dialogBox.TypeDialog($"A wild {playerUnit.Spirimon.Base.Name} Appeared!"));
    }
}
