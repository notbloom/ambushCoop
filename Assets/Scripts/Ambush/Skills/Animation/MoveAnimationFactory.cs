using System.Collections;
using UnityEngine;

namespace Ambush
{
    [CreateAssetMenu(fileName = "new MoveAnimation", menuName = "Factory/Animation/MoveAnimationFactory", order = 0)]
    public class MoveAnimationFactory : ScriptableObject
    {
        public float animationTime;

        public MoveAnimationCommand Generate(BoardAgent agent, Node to)
        {
            return new MoveAnimationCommand(agent.view.Transform(), to, animationTime);
        }
    }

    public class MoveAnimationCommand : AnimationCommand
    {
        public float animationTime;
        public Vector3 destination;
        public Vector3 origin;
        public float startTime;
        public Transform transform;

        public MoveAnimationCommand(Transform transform, Node to, float animationTime)
        {
            this.transform = transform;
            destination = to.ToVector3();
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
}