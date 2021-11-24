using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

[CreateAssetMenu(fileName = "new BaseAttackAction", menuName = "TurnActions/BaseAttackAction", order = 0)]
public class BaseAttackAction : ScriptableAction
{
    // public int targets;
    // public float damage;
    // public int range;
    // public List<Status> statuses;

    public NodeAnimationFactory animationFactory;
    public override void PerformAction(HNode from, List<HNode> targets, AgentBase agent)
    {
        //   Debug.Log("attacking cleave");
        foreach (HNode target in targets)
        {
            //     Debug.Log(target.ToString());
            if (target.occupant != null)
            {
                //        Debug.Log("occupant found");
                if (target.occupant.agent != null)
                {
                    //          Debug.Log("agent not null");

                    HDamageInstance damageInstance = new HDamageInstance(agent.agent.attack);
                    DamageAnimationFactory.damageInstance = damageInstance;
                    //TODO create a DamageAnimationFactory
//                    AnimationInvoker.Enqueue(animationFactory.Generate(agent.gameObject, new List<HNode>() { from }, new List<HNode>() { target }, 0.2f));
                    target.occupant.agent.ReceiveDamage(damageInstance);
                }
            }
        }
        //   Debug.Log("attacked cleave");
    }
}
