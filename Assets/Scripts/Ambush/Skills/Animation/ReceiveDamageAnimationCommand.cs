using System.Collections;
using UnityEngine;

namespace Ambush
{
    public class ReceiveDamageAnimationCommand : AnimationCommand
        {
            public float animationTime;
            private readonly IAgentBehaviour agentBehaviour;
            public float startTime;
            public float startingHp;
            public float endingHp;

            public ReceiveDamageAnimationCommand(IAgentBehaviour agentBehaviour, float endingHp, float animationTime)
            {
                this.agentBehaviour = agentBehaviour;
                this.endingHp = endingHp;
                this.animationTime = animationTime;
            }

            public override IEnumerator Animate()
            {
                startingHp = agentBehaviour.CurrentHp();
                startTime = Time.time;
                yield return _Animate();
            }

            private IEnumerator _Animate()
            {
                while (Time.time < startTime + animationTime)
                {
                    agentBehaviour.ShowHP( Mathf.Lerp(startingHp, endingHp, (Time.time - startTime) / animationTime));
                    //agent.UpdateView();
                    yield return null;
                }

                //TODO change this math to agent damage processing
                agentBehaviour.ShowHP(endingHp);
                //agent.UpdateView();
            }


        }
    }
