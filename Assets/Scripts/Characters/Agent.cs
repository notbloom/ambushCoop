using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public VisibleCharacter visibleCharacter;
    public BaseStats baseStats;
    public BaseStats roundStats;
    public List<Status> resistances;
    public List<Status> status;

    private SpriteRenderer spriteRenderer;
    public int hp;
    // Start is called before the first frame update

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

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = visibleCharacter.sprite;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
