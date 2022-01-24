using System.Collections;
using UnityEngine;

namespace Ambush
{
    [CreateAssetMenu(fileName = "new ThrowableAnimationFactory",
        menuName = "Factory/Animation/ThrowableAnimationFactory", order = 0)]
    public class ThrowableAnimationFactory : ScriptableObject
    {
        public float animationTime;
        public GameObject spawnGameobject;

        public ThrowableAnimationCommand Generate(Node from, Node to)
        {
            var animationCommand = new ThrowableAnimationCommand(from, to, animationTime);
            animationCommand.spawnGameobject = spawnGameobject;
            return animationCommand;
        }
    }

    public class ThrowableAnimationCommand : AnimationCommand
    {
        public float animationTime;
        private GameObject clone;
        private readonly Node from;
        public GameObject spawnGameobject;
        public float startTime;

        private readonly Node to;

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
            clone = Instantiate(spawnGameobject, from.ToVector3(), spawnGameobject.transform.rotation);
            Debug.Log("Spawn animator called");
            yield return _Animate();
        }

        private IEnumerator _Animate()
        {
            while (Time.time < startTime + animationTime)
            {
                clone.transform.position = Vector3.Lerp(from.ToVector3(), to.ToVector3(),
                    (Time.time - startTime) / animationTime);
                // agent.hp = Mathf.Lerp(startingHp, startingHp - damageInstance.amount, (Time.time - startTime) / animationTime);
                // agent.UpdateView();
                yield return null;
            }

            Destroy(clone);
        }
    }
}