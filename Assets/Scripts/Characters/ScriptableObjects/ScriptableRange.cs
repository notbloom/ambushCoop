using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

public abstract class ScriptableRange : ScriptableObject
{
    public abstract List<HNode> Area(HNode origin);
}

