using UnityEngine;
using System.Collections.Generic;
namespace Ambush
{
    [CreateAssetMenu(fileName = "new SimpleAttackFactory", menuName = "ActionFactory/SimpleAttackFactory", order = 0)]
    public class MoveFactory : ActionFactory{
        
        public int steps = 2;

        public ThrowableAnimationFactory animationFactory;
        
        public override IActionController Generate() {
            
            SimpleAttackController controller = new SimpleAttackController();

            controller.cost = cost;
            controller.steps = steps;
            controller.animationFactory = animationFactory;

            return controller;
        }
      
    }
}