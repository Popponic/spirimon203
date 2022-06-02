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
    public int currentAction { get; set; }
    public int currentMove { get; set; }

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

        dialogBox.SetMoveNames(playerUnit.Spirimon.Moves);

        yield return dialogBox.TypeDialog($"A wild {enemyUnit.Spirimon.Base.Name} Appeared!");

        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PLAYER_ACTION;
        StartCoroutine(dialogBox.TypeDialog($"What will {playerUnit.Spirimon.Base.Name} do?"));
        dialogBox.EnableActionSelector(true);
    }

    void PlayerMove()
    {
        state = BattleState.PLAYER_MOVE;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableMoveSelector(true);
    }

    IEnumerator PerformPlayerMove()
    {
        state = BattleState.BUSY;
        var move = playerUnit.Spirimon.Moves[currentMove - 1];
        yield return dialogBox.TypeDialog($"{playerUnit.Spirimon.Base.Name} used {move.Base.Name}");

        playerUnit.PlayAttackAnimation();
        enemyUnit.PlayHitAnimation();

        var damageDetails = enemyUnit.Spirimon.TakeDamage(move, playerUnit.Spirimon);
        yield return enemyHUD.UpdateHP();
        yield return ShowDamageDetails(damageDetails);

        if(damageDetails.HasFainted)
        {
            yield return dialogBox.TypeDialog($"{enemyUnit.Spirimon.Base.Name} Fainted!");
            currentAction = 0;
            currentMove = 0;
            enemyUnit.PlayFaintAnimation();
        }
        else
        {
            currentAction = 0;
            currentMove = 0;
            StartCoroutine(PerformEnemyMove());
        }
    }

    IEnumerator PerformEnemyMove()
    {
        state = BattleState.ENEMY_MOVE;
        var move = enemyUnit.Spirimon.GetRandomMove();

        yield return dialogBox.TypeDialog($"{enemyUnit.Spirimon.Base.Name} used {move.Base.Name}");

        enemyUnit.PlayAttackAnimation();
        playerUnit.PlayHitAnimation();

        var damageDetails = playerUnit.Spirimon.TakeDamage(move, enemyUnit.Spirimon);
        yield return playerHUD.UpdateHP();
        yield return ShowDamageDetails(damageDetails);

        if (damageDetails.HasFainted)
        {
            yield return dialogBox.TypeDialog($"{playerUnit.Spirimon.Base.Name} Fainted!");
            currentAction = 0;
            currentMove = 0;
            playerUnit.PlayFaintAnimation();
        }
        else
        {
            currentAction = 0;
            currentMove = 0;
            PlayerAction();
        }
    }

    IEnumerator ShowDamageDetails(Spirimon.DamageDetails damageDetails)
    {
        if (damageDetails.CriticalHit > 1f)
            yield return dialogBox.TypeDialog("A critical hit!");


        if (damageDetails.TypeEffectiveness > 1)
            yield return dialogBox.TypeDialog("It's super effective!");

        else if (damageDetails.TypeEffectiveness < 1)
            yield return dialogBox.TypeDialog("It's not very effective.");

        else if (damageDetails.TypeEffectiveness < 0)
            yield return dialogBox.TypeDialog("It's not effective.");

    }

    private void Update()
    {
        if(state == BattleState.PLAYER_ACTION)
        {
            HandleActionSelection();
        } else if(state == BattleState.PLAYER_MOVE)
        {
            HandleMoveSelection();
        }
    }

    void HandleActionSelection()
    {
        if(currentAction == 1) // FIGHT
        {
            PlayerMove();
        }

        // NOTE: Add other actions and their respective functions here once implemented
    }

    void HandleMoveSelection()
    {
        switch(currentMove)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                dialogBox.EnableMoveSelector(false);
                StartCoroutine(PerformPlayerMove());
                break;
            default:
                break;

        }
    }
}
