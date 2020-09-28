using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

[CreateAssetMenu(fileName = "AOE", menuName = "AOE", order = 0)]
public class ScriptableAOE : ScriptableObject
{
    public ScriptableArea Range;
    public ScriptableArea Area;

    // List<HNode> Area(HNode origin, HNode target);
}
