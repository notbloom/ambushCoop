using UnityEngine;
using System.Collections.Generic;
namespace Ambush
{
    [CreateAssetMenu(fileName = "new MoveActionFactory", menuName = "ActionFactory/MoveActionFactory", order = 0)]
    public class MoveActionFactory : ActionFactory{
        
        public int steps = 2;

        public MoveAnimationFactory animationFactory;
        
        //public override IActionController Generate() {
            
        //    MoveActionController controller = new MoveActionController();
        //    controller.uiSprite = uiSprite;
        //    controller.steps = steps;
        //    controller.animationFactory = animationFactory;

        //    return controller;
        //}
      
    }
}