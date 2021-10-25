using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

public abstract class ScriptableArea : ScriptableObject
{
    public abstract List<HNode> Area(HNode origin, HNode target);
}
