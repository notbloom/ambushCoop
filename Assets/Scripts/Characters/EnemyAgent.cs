using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgent : ScriptableAgent
{
    public virtual void OnSpawn()
    {
        base.OnSpawn();
    }
    public virtual void OnTurnStart()
    {

    }
    public virtual void OnTurnEnd()
    {

    }
    public void EvaluateRoundState(RoundModifier roundModifier)
    {
        roundStats.move = roundModifier.setMove ? roundModifier.move : baseStats.move + roundModifier.move;
        roundStats.armor = roundModifier.setArmor ? roundModifier.armor : baseStats.armor + roundModifier.armor;
        roundStats.attack = roundModifier.setAttack ? roundModifier.attack : baseStats.attack + roundModifier.attack;
        roundStats.targets = roundModifier.setTargets ? roundModifier.targets : baseStats.targets + roundModifier.targets;
    }
    public void ApplyStatus(Status _status)
    {
        //RESIST 
        if (resistances.Contains(_status))
            return;
        if (status.Contains(_status))
        {
            //status.Find(_status).ticks += _status.ticks;
        }
        else
        {
            status.Add(_status);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
