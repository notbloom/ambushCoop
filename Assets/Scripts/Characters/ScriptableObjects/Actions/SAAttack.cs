using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

[CreateAssetMenu(fileName = "new Attack", menuName = "TurnActions/Attack", order = 0)]
public class SAAttack : ScriptableAction
{
    public int targets;
    public float damage;
    public int range;
    public List<Status> statuses;
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
                    AnimationInvoker.Enqueue(animationFactory.Generate(agent.gameObject, new List<HNode>() { from }, new List<HNode>() { target }, 0.2f));
                    DamageAnimationFactory.damageInstance = new HDamageInstance(damage);
                    target.occupant.agent.ReceiveDamage(new HDamageInstance(damage));
                }
            }
        }
        //   Debug.Log("attacked cleave");
    }
}
