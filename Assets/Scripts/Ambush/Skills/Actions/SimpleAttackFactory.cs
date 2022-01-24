using UnityEngine;

namespace Ambush
{
    [CreateAssetMenu(fileName = "new SimpleAttackFactory", menuName = "ActionFactory/SimpleAttackFactory", order = 0)]
    public class SimpleAttackFactory : ActionFactory
    {
        public ThrowableAnimationFactory animationFactory;

        //  public Sprite uiSprite;

        //public int cost = 1;        
        public int damage = 5;
        public int range = 1;

        public override IActionController Generate()
        {
            var controller = new SimpleAttackController();

            controller.cost = cost;
            controller.uiSprite = uiSprite;
            controller.damage = damage;
            controller.range = range;
            controller.animationFactory = animationFactory;

            return controller;
        }
        // public IActionController GenerateNew()
        // {
        //
        //     SimpleAttackAction action = new SimpleAttackAction();
        //
        //     action.cost = cost;
        //     action.damage = damage;
        //     action.range = range;
        //     action.animationFactory = animationFactory;
        //
        //     return action;
        // }
    }
}