using UnityEngine;
using System.Collections.Generic;
namespace Ambush
{
    [CreateAssetMenu(fileName = "new SimpleAttackFactory", menuName = "ActionFactory/SimpleAttackFactory", order = 0)]
    public class SimpleAttackFactory : ActionFactory{

      //  public Sprite uiSprite;

        //public int cost = 1;        
        public int damage = 5;
        public int range = 1;

        public ThrowableAnimationFactory animationFactory;
        
        public override IActionController Generate() {

            SimpleAttackAction action = new SimpleAttackAction();

            action.cost = cost;
            action.damage = damage;
            action.range = range;
            action.animationFactory = animationFactory;

            return action;
        }
        public IActionController GenerateNew()
        {

            SimpleAttackAction action = new SimpleAttackAction();

            action.cost = cost;
            action.damage = damage;
            action.range = range;
            action.animationFactory = animationFactory;

            return action;
        }
    }
}