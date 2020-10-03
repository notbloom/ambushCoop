using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

public class EnemyAgent : AgentBase
{
    public List<ScriptableCard> cards;
    public ScriptableCard currentCard => cards[actionCount];
    // Start is called before the first frame update
    void Awake()
    {
        agent = new Agent();
    }
    void Start()
    {
        base.Init();
        transform.position = node.ToVector3();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override string Intent()
    {
        string intent = "";
        foreach (ScriptableCard card in cards)
        {
            intent += card.description + "\n";
        }
        return intent;
    }
    public override void PlayTurn()
    {
        foreach (ScriptableCard card in cards)
        {
            card.AITurn(node, this);
        }
        RoundsEngine.EndTurn(this);
    }
    public void ClickOnNode(HNode node)
    {

        PerformAction(cards[actionCount], new List<HNode>() { node });
        actionCount++;
        if (actionCount == cards.Count)
            actionCount = 0;
    }
    public void PerformAction(ScriptableCard action, List<HNode> targets)
    {
        // action.PerformAction(agent.node, targets, );
    }
    // public void EvaluateRoundState(RoundModifier roundModifier)
    // {
    //     roundStats.move = roundModifier.setMove ? roundModifier.move : baseStats.move + roundModifier.move;
    //     roundStats.armor = roundModifier.setArmor ? roundModifier.armor : baseStats.armor + roundModifier.armor;
    //     roundStats.attack = roundModifier.setAttack ? roundModifier.attack : baseStats.attack + roundModifier.attack;
    //     roundStats.targets = roundModifier.setTargets ? roundModifier.targets : baseStats.targets + roundModifier.targets;
    // }
    // public void ApplyStatus(Status _status)
    // {
    //     //RESIST 
    //     if (resistances.Contains(_status))
    //         return;
    //     if (status.Contains(_status))
    //     {
    //         //status.Find(_status).ticks += _status.ticks;
    //     }
    //     else
    //     {
    //         status.Add(_status);
    //     }
    // }

}
