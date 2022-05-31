using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    START,
    PLAYER_ACTION,
    PLAYER_MOVE,
    ENEMY_MOVE,
    BUSY
}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleHUD playerHUD;

    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHUD enemyHUD;

    [SerializeField] BattleDialogBox dialogBox;

    BattleState state;
    int currentAction;

    private void Start()
    {
        StartCoroutine(InitBattle());
    }


    public IEnumerator InitBattle()
    {
        playerUnit.Setup();
        playerHUD.SetData(playerUnit.Spirimon);

        enemyUnit.Setup();
        enemyHUD.SetData(enemyUnit.Spirimon);

        yield return dialogBox.TypeDialog($"A wild {enemyUnit.Spirimon.Base.Name} Appeared!");
        yield return new WaitForSeconds(1.0f);

        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PLAYER_ACTION;
        StartCoroutine(dialogBox.TypeDialog($"What will {playerUnit.Spirimon.Base.Name} do?"));
        dialogBox.EnableActionSelector(true);
    }

    private void Update()
    {
        if(state == BattleState.PLAYER_ACTION)
        {
            HandleActionSelection();
        }
    }

    void HandleActionSelection()
    {

    }
}
