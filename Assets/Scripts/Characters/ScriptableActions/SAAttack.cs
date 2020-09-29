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
    public override void PerformAction(HNode from, List<HNode> targets, AgentBase agent)
    {
        Debug.Log("attacking cleave");
        foreach (HNode target in targets)
        {
            Debug.Log(target.ToString());
            if (target.occupant != null)
            {
                Debug.Log("occupant found");
                if (target.occupant.agent != null)
                {
                    Debug.Log("agent not null");
                    AnimationInvoker.Enqueue(new DamageAnimation(target.occupant.agent, new HDamageInstance(damage), 0.2f));
                }
            }
        }
        Debug.Log("attacked cleave");
    }
}
