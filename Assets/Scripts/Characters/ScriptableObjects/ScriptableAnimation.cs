using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using notbloom.HexagonalMap;

public abstract class NodeAnimationFactory : ScriptableObject
{
    public float animationTime = 0.2f;
    public abstract AnimationCommand Generate(GameObject caster, List<HNode> from, List<HNode> to, float animationTime);
    // public abstract IEnumerator Animate();
    // HNode from;
    // List<HNode> to;
    // public NodeAnimationFactory(HNode from, List<HNode> to)
    // {
    //     this.from = from;
    //     this.to = to;
    // }

}

public abstract class AnimationCommand : ScriptableObject
{
    public abstract IEnumerator Animate();
}
