using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ambush
{
    
    [CreateAssetMenu(fileName = "new DamageAnimationFactory", menuName = "Animation/DamageAnimationFactory", order = 0)]

    public class DamageAnimationFactory : ScriptableObject
    {
        //static public int damageInstance;
        public float animationTime;
        
        public DamageAnimationCommand Generate(BoardAgent agent, int damageInstance)
        {
            return new DamageAnimationCommand(agent, damageInstance, animationTime);
        }
    }
    public class DamageAnimationCommand : AnimationCommand
    {
        public float animationTime;        
        public int damageInstance;
        public BoardAgent agent;
        public float startTime;

        public int startingHp;

        public DamageAnimationCommand(BoardAgent agent, int damageInstance, float animationTime)
        {

            this.agent = agent;
            this.damageInstance = damageInstance;
            this.animationTime = animationTime;
        }
        public override IEnumerator Animate()
        {
            startingHp = agent.currentHealth;
            startTime = Time.time;
            yield return _Animate();
        }
        private IEnumerator _Animate()
        {
            while (Time.time < startTime + animationTime)
            {
                agent.currentHealth = (int) Mathf.Lerp(startingHp, startingHp - damageInstance, (Time.time - startTime) / animationTime);
                //agent.UpdateView();
                yield return null;
            }
            //TODO change this math to agent damage processing
            agent.currentHealth = startingHp - damageInstance;
            //agent.UpdateView();
        }

    }
}