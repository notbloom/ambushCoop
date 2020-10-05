using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System;
//[CreateAssetMenu(fileName = "ScriptableAgent", menuName = "Char/Agent", order = 0)]

//TODO rename to AgentEngine or something similar
public class Agent : HObject, HICanReceiveDamage
{
    //Scriptable Objects
    public VisibleObject visibleCharacter;
    public BaseStats baseStats;
    public List<Status> resistances;
    //Variables
    public List<Status> status;
    public BaseStats roundStats;
    //private SpriteRenderer spriteRenderer;
    public float hp = 100f;
    public float maxHp = 100f;

    public int attack => baseStats.attack;
    public Action<HDamageInstance> ReceiveDamageCall;

    public Agent()
    {
        agent = this;
        hp = 100;
    }
    // Start is called before the first frame update

    public virtual void ReceiveDamage(HDamageInstance damageInstance)
    {
        hp -= damageInstance.amount;
        ReceiveDamageCall(damageInstance);
    }
    public virtual void OnSpawn()
    {
        roundStats = new BaseStats();

    }
    public virtual void OnTurnStart()
    {

    }
    public virtual void OnTurnEnd()
    {

    }
    public virtual void OnRoundStart()
    {

    }
    public virtual void OnRoundEnd()
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
            //status.Find(_status)[0].ticks += _status.ticks;
        }
        else
        {
            status.Add(_status);
        }
    }

}
