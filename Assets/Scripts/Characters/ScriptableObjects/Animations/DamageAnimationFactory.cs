// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using notbloom.HexagonalMap;
// [CreateAssetMenu(fileName = "new DamageAnimationFactory", menuName = "Animation/DamageAnimationFactory", order = 0)]
//
// public class DamageAnimationFactory : NodeAnimationFactory
// {
//     static public HDamageInstance damageInstance;
//
//     public AnimationCommand Generate(GameObject caster, List<HNode> from, List<HNode> to, HDamageInstance _damageInstance, float animationTime)
//     {
//         return new DamageAnimationCommand(caster.GetComponent<AgentBase>().agent, from[0], to, _damageInstance, animationTime);
//     }
//     public override AnimationCommand Generate(GameObject caster, List<HNode> from, List<HNode> to, float animationTime)
//     {
//         return new DamageAnimationCommand(caster.GetComponent<AgentBase>().agent, from[0], to, damageInstance, animationTime);
//     }
// }
// public class DamageAnimationCommand : AnimationCommand
// {
//     public float animationTime;
//     public Agent agent;
//     public HDamageInstance damageInstance;
//     public float startTime;
//
//     public float startingHp;
//
//     public DamageAnimationCommand(Agent agent, HNode from, List<HNode> to, HDamageInstance damageInstance, float animationTime)
//     {
//
//         this.agent = agent;
//         this.damageInstance = damageInstance;
//         this.animationTime = animationTime;
//     }
//     public override IEnumerator Animate()
//     {
//         startingHp = agent.hp;
//         startTime = Time.time;
//         yield return _Animate();
//     }
//     private IEnumerator _Animate()
//     {
//         while (Time.time < startTime + animationTime)
//         {
//             agent.hp = Mathf.Lerp(startingHp, startingHp - damageInstance.amount, (Time.time - startTime) / animationTime);
//             //agent.UpdateView();
//             yield return null;
//         }
//         //TODO change this math to agent damage processing
//         agent.hp = startingHp - damageInstance.amount;
//         //agent.UpdateView();
//     }
//
// }