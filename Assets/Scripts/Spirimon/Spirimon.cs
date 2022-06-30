using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirimon
{
    public SpirimonBase Base { get; set; }
    public int Level { get; set; }

    public int HP { get; set; }

    public int SP { get; set; }

    public List<Move> Moves { get; set; }

    public int ActiveAbility { get; set; } = 0;

    public float AbilityModifier { get; set; }

    public Spirimon(SpirimonBase sb, int lvl)
    {
        Base = sb;
        Level = lvl;
        HP = MaxHP;
        SP = MaxSP;
        

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
        get { return Mathf.FloorToInt((2 * Base.MaxHp * Level / 100) + Level + 10); }
    }

    public int MaxSP
    {
        get { return Mathf.FloorToInt(25 + Level * 5); }
    }

    public DamageDetails TakeDamage(Move move, Spirimon attacker)
    {

        float criticalHit = 1f;
        if (Random.value * 100f <= 6.25f)
            criticalHit = 2f;

        float type = TypeChart.GetEffectiveness(move.Base.Type, this.Base.Type1) *
            TypeChart.GetEffectiveness(move.Base.Type, this.Base.Type2);

        var damageDetails = new DamageDetails()
        {
            HasFainted = false,
            CriticalHit = criticalHit,
            TypeEffectiveness = type
        };

        float mod = Random.Range(0.85f, 1.0f) * type * criticalHit;
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * (move.Base.Power * attacker.AbilityModifier) * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * mod);

        HP -= damage;
        if(HP <= 0)
        {
            HP = 0;
            damageDetails.HasFainted = true;
        }

        return damageDetails;
    }

    public SPDetails UseSP(Move move)
    {
        int spcost = move.Base.SpCost;

        var spDetails = new SPDetails();
   
        if (SP < spcost)
        {
            spDetails.NoSP = true;
        } 
        else
        {
            SP -= spcost;
            
        }
        
        return spDetails;

    }

    public Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }

    public class DamageDetails
    {
        public bool HasFainted { get; set; }
        public float CriticalHit { get; set; }
        public float TypeEffectiveness { get; set; }
    }

    public class SPDetails
    {
        public bool NoSP { get; set; }
    }

    void PlayerAbilityCheck(Move move, Spirimon attacker)
    {

    }
}
