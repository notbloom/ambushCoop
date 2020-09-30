using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

public class MoveAnimation : ScriptableNodeAnimation
{
    public float animationTime;
    public Transform transform;
    public Vector3 origin;
    public Vector3 destination;
    public float startTime;

    public MoveAnimation(Transform transform, HNode from, HNode to, float animationTime) : base(from, new List<HNode>() { to })
    {

        this.transform = transform;
        this.destination = to.ToVector3();
        this.animationTime = animationTime;
    }
    public override IEnumerator Animate()
    {
        origin = transform.position;
        startTime = Time.time;
        yield return _Animate();
    }
    private IEnumerator _Animate()
    {
        while (Time.time < startTime + animationTime)
        {
            transform.position = Vector3.Lerp(origin, destination, (Time.time - startTime) / animationTime);
            yield return null;
        }
        transform.position = destination;
    }

}