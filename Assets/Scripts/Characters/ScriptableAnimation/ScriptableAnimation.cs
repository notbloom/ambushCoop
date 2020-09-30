using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using notbloom.HexagonalMap;

public abstract class ScriptableNodeAnimation : ScriptableObject
{
    public abstract IEnumerator Animate();
    HNode from;
    List<HNode> to;
    public ScriptableNodeAnimation(HNode from, List<HNode> to)
    {
        this.from = from;
        this.to = to;
    }

}

public abstract class AnimatorCommand
{
    public abstract IEnumerator Animate();
}
