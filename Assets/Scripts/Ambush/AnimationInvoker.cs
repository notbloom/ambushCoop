using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ambush
{
    public class AnimationInvoker : MonoBehaviour
    {
        static AnimationInvoker instance;
        public Transform target;
        Queue<AnimationCommand> animationCommands;

        private bool busy = false;
        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            } 
            
            animationCommands = new Queue<AnimationCommand>();
        }
        void Update()
        {
            if (busy)
                return;
            if (animationCommands.Count > 0)
                Step();
        }
        public static void Enqueue(AnimationCommand animationCommand)
        {
            instance.animationCommands.Enqueue(animationCommand);
        }
        public void Step()
        {
            busy = true;
            StartCoroutine(StartStep(callBack =>
            {
            // callBack is going to be null until it’s set
            if (callBack != null)
                {
                    busy = false;
                // Now callBack acts as an int
                // Debug.Log(callBack);
            }
            }));
        }

        public IEnumerator StartStep(System.Action<string> callBack)
        {
            //MoveAnimation m = new MoveAnimation(target, Vector3.zero, 100f);

            // Waits 3 seconds
            yield return animationCommands.Dequeue().Animate(); // m.Animate();

            // Set callBack to 1 after 3 seconds
            callBack("animator");
        }
    }

    // public abstract class ScriptableAnimation : ScriptableObject
    // {
    //     public abstract IEnumerator Animate();
    // }


}