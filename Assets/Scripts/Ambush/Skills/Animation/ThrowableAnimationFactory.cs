using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Ambush
{
    

[CreateAssetMenu(fileName = "new ThrowableAnimationFactory", menuName = "Factory/Animation/ThrowableAnimationFactory", order = 0)]

public class ThrowableAnimationFactory : ScriptableObject
{
    public GameObject spawnGameobject;
    public float animationTime;
    public ThrowableAnimationCommand Generate(Node from, Node to)
    {
        ThrowableAnimationCommand animationCommand = new ThrowableAnimationCommand(from, to, animationTime);
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

    Node to;
    Node from;
    public ThrowableAnimationCommand(Node from, Node to, float animationTime)
    {
        this.to = to;
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
}