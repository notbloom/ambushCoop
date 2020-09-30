using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

[CreateAssetMenu(fileName = "new MoveAnimation", menuName = "Animation/MoveAnimationFactory", order = 0)]

public class MoveAnimation : NodeAnimationFactory
{
    public override AnimationCommand Generate(GameObject caster, List<HNode> from, List<HNode> to, float animationTime)
    {
        return new MoveAnimationCommand(caster.transform, from[0], to[0], animationTime);
    }
}
public class MoveAnimationCommand : AnimationCommand
{
    public float animationTime;
    public Transform transform;
    public Vector3 origin;
    public Vector3 destination;
    public float startTime;

    public MoveAnimationCommand(Transform transform, HNode from, HNode to, float animationTime)
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