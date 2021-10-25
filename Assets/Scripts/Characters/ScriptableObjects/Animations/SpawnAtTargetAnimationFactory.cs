using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
[CreateAssetMenu(fileName = "new SpawnAtTargetAnimationFactory", menuName = "Animation/SpawnAtTargetAnimationFactory", order = 0)]

public class SpawnAtTargetAnimationFactory : NodeAnimationFactory
{
    public GameObject spawnGameobject;
    public override AnimationCommand Generate(GameObject caster, List<HNode> from, List<HNode> to, float animationTime)
    {
        SpawnAtTargetAnimationCommand animationCommand = new SpawnAtTargetAnimationCommand(caster.GetComponent<AgentBase>().agent, from[0], to, this.animationTime);
        animationCommand.spawnGameobject = spawnGameobject;
        return animationCommand;
    }
}
public class SpawnAtTargetAnimationCommand : AnimationCommand
{
    public GameObject spawnGameobject;
    private GameObject clone;
    public float animationTime;
    public float startTime;

    List<HNode> to;

    public SpawnAtTargetAnimationCommand(Agent agent, HNode from, List<HNode> to, float animationTime)
    {
        this.to = to;
        this.animationTime = animationTime;
        Debug.Log("Spawn animator called");
    }
    public override IEnumerator Animate()
    {
        startTime = Time.time;
        clone = GameObject.Instantiate(spawnGameobject, to[0].ToVector3(), spawnGameobject.transform.rotation);
        Debug.Log("Spawn animator called");
        yield return _Animate();
    }
    private IEnumerator _Animate()
    {
        while (Time.time < startTime + animationTime)
        {
            // agent.hp = Mathf.Lerp(startingHp, startingHp - damageInstance.amount, (Time.time - startTime) / animationTime);
            // agent.UpdateView();
            yield return null;
        }
        GameObject.Destroy(clone);
    }

}