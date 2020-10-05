using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
[CreateAssetMenu(fileName = "new ThrowableAnimationFactory", menuName = "Animation/ThrowableAnimationFactory", order = 0)]

public class ThrowableAnimationFactory : NodeAnimationFactory
{
    public GameObject spawnGameobject;
    public override AnimationCommand Generate(GameObject caster, List<HNode> from, List<HNode> to, float animationTime)
    {
        ThrowableAnimationCommand animationCommand = new ThrowableAnimationCommand(caster.GetComponent<AgentBase>().agent, from[0], to, this.animationTime);
        animationCommand.spawnGameobject = spawnGameobject;
        return animationCommand;
    }
}
public class ThrowableAnimationCommand : AnimationCommand
{
    public GameObject spawnGameobject;
    private GameObject clone;
    public float animationTime;
    public float startTime;

    HNode to;
    HNode from;
    public ThrowableAnimationCommand(Agent agent, HNode from, List<HNode> to, float animationTime)
    {
        this.to = to[0];
        this.animationTime = animationTime;
        this.from = from;
        Debug.Log("Spawn animator called");
    }
    public override IEnumerator Animate()
    {
        startTime = Time.time;
        clone = GameObject.Instantiate(spawnGameobject, from.ToVector3(), spawnGameobject.transform.rotation);
        Debug.Log("Spawn animator called");
        yield return _Animate();
    }
    private IEnumerator _Animate()
    {
        while (Time.time < startTime + animationTime)
        {
            clone.transform.position = Vector3.Lerp(from.ToVector3(), to.ToVector3(), (Time.time - startTime) / animationTime);
            // agent.hp = Mathf.Lerp(startingHp, startingHp - damageInstance.amount, (Time.time - startTime) / animationTime);
            // agent.UpdateView();
            yield return null;
        }
        GameObject.Destroy(clone);
    }

}