using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

[CreateAssetMenu(fileName = "Move", menuName = "TurnActions/Move", order = 0)]
public class SAMove : ScriptableAction
{
    public int moveAmount;
    public override void PerformAction(HNode from, List<HNode> targets)
    {
        HMapController map = new HMapController();
        map.StepObjectTo(from.occupant, targets[0]);
    }
}
