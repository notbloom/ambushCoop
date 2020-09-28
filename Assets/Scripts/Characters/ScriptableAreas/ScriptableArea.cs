using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

public abstract class ScriptableArea : ScriptableObject
{
    public abstract List<HNode> Targets(HNode origin, HNode target);
}
