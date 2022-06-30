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
        var spDetails = playerUnit.Spirimon.UseSP(move);
        print(playerUnit.Spirimon.SP + " - " + move.Base.SpCost);
        if (spDetails.NoSP == true)
        {
            currentAction = 0;
            currentMove = 0;
            yield return dialogBox.TypeDialog($"{playerUnit.Spirimon.Base.Name} does not have enough SP!");
            PlayerMove();
        } 
        else
        {
            yield return dialogBox.TypeDialog($"{playerUnit.Spirimon.Base.Name} used {move.Base.Name}");
            yield return playerHUD.UpdateSP();

            playerUnit.PlayAttackAnimation();
            enemyUnit.PlayHitAnimation();

            CheckAbility(move, playerUnit.Spirimon);
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
        
    }

    IEnumerator PerformEnemyMove()
    {
        state = BattleState.ENEMY_MOVE;
        bool validMove = false;
        var move = enemyUnit.Spirimon.GetRandomMove();
        while (validMove == false)
        {
            move = enemyUnit.Spirimon.GetRandomMove();
            var spDetails = enemyUnit.Spirimon.UseSP(move);
            if (spDetails.NoSP == true)
            {
                print("Enemy rerolled move due to insufficient SP.");

            }
            else
            {
                validMove = true;
            }
        }
        
        yield return dialogBox.TypeDialog($"{enemyUnit.Spirimon.Base.Name} used {move.Base.Name}");
        yield return enemyHUD.UpdateSP();

        enemyUnit.PlayAttackAnimation();
        playerUnit.PlayHitAnimation();

        CheckAbility(move, enemyUnit.Spirimon);
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

        else if (damageDetails.TypeEffectiveness < 1 && damageDetails.TypeEffectiveness >= 0.5)
            yield return dialogBox.TypeDialog("It's not very effective.");

        else if (damageDetails.TypeEffectiveness < 0.5)
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

    void CheckAbility(Move move, Spirimon spirimon) // Move to be used :: Current move
    {
        Debug.Log("Entered CheckAbility");
        playerUnit.Spirimon.AbilityModifier = 1;
        enemyUnit.Spirimon.AbilityModifier = 1;

        // Attack boost calcs
        // Thunder Torque
        if (move.Base.AdditionalType == AdditionalType.Rolling && spirimon.Base.UseableAbilities[spirimon.ActiveAbility].Type == AbilityType.Rolling)
        {
            playerUnit.Spirimon.AbilityModifier = spirimon.Base.UseableAbilities[spirimon.ActiveAbility].Modifier;
            enemyUnit.Spirimon.AbilityModifier = spirimon.Base.UseableAbilities[spirimon.ActiveAbility].Modifier;
            Debug.Log("Entered Rolling check");
            Debug.Log($"Player and Enemy Modifiers :: {playerUnit.Spirimon.AbilityModifier} and {enemyUnit.Spirimon.AbilityModifier}");
            //yield return dialogBox.TypeDialog($"Thunder Torque increased the power of {move.Base.Name}");
        }

        // Erosion Boots
        if (move.Base.AdditionalType == AdditionalType.Kicking && spirimon.Base.UseableAbilities[spirimon.ActiveAbility].Type == AbilityType.Kicking)
        {
            playerUnit.Spirimon.AbilityModifier = spirimon.Base.UseableAbilities[spirimon.ActiveAbility].Modifier;
            enemyUnit.Spirimon.AbilityModifier = spirimon.Base.UseableAbilities[spirimon.ActiveAbility].Modifier;
            Debug.Log("Entered Kicking check");
            //yield return dialogBox.TypeDialog($"Erosion Boots increased the power of {move.Base.Name}");
        }

        // Malestrom Fists
        if (move.Base.AdditionalType == AdditionalType.Punching && spirimon.Base.UseableAbilities[spirimon.ActiveAbility].Type == AbilityType.Punching)
        {
            playerUnit.Spirimon.AbilityModifier = spirimon.Base.UseableAbilities[spirimon.ActiveAbility].Modifier;
            enemyUnit.Spirimon.AbilityModifier = spirimon.Base.UseableAbilities[spirimon.ActiveAbility].Modifier;
            Debug.Log("Entered Punching check");
            //yield return dialogBox.TypeDialog($"Malestrom Fists increased the power of {move.Base.Name}");
        }
    }
}
