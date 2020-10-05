using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;

[CreateAssetMenu(fileName = "SingleTargetArea", menuName = "Area/SingleTargetArea", order = 0)]

public class SingleTargetArea : ScriptableArea
{
    public override List<HNode> Area(HNode origin, HNode target)
    {
        return new List<HNode>() { target };
    }
}
