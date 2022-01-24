using UnityEngine;

namespace Ambush
{
    [CreateAssetMenu(fileName = "new MoveActionFactory", menuName = "ActionFactory/MoveActionFactory", order = 0)]
    public class MoveActionFactory : ActionFactory
    {
        public MoveAnimationFactory animationFactory;

        public int steps = 2;

        //public override IActionController Generate() {

        //    MoveActionController controller = new MoveActionController();
        //    controller.uiSprite = uiSprite;
        //    controller.steps = steps;
        //    controller.animationFactory = animationFactory;

        //    return controller;
        //}
    }
}