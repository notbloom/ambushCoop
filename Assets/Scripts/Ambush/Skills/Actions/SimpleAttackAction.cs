using UnityEngine;
using System.Collections.Generic;
namespace Ambush
{
    
    public class SimpleAttackAction : IActionController
    {
        [SerializeField]
        public int cost = 1;
        private bool active = false;
        public int damage = 5;
        public int range = 1;
        public BoardFaction targetFaction = BoardFaction.Enemy;
        
        public ThrowableAnimationFactory animationFactory;

        public int Cost() => cost;

        public void ApplyAction()
        {
            //calcute damg
        }

        public void OnSkillHover(PlayerBehaviour playerBehaviour)
        {
            // SHOW RANGE
            Debug.Log(playerBehaviour.position.ToString());
            AreaView.ShowRange(Range.Circle(playerBehaviour.position, range));
        }

        public void OnSkillExitHover(PlayerBehaviour playerBehaviour)
        {
            // HIDE RANGE
            if (!active)
            {
                AreaView.HideArea(); //TODO reset range?
                AreaView.HideRange();
                AreaView.ResetView();
            }
                //playerBehaviour.ResetRange();
        }

        public void OnSkillActivate(PlayerBehaviour playerBehaviour){
            active = true;
            
        }

        public void OnSkillCancel(PlayerBehaviour playerBehaviour)
        {
            //playerBehaviour.RegisterAction(this);
            playerBehaviour.ResetRange();
            active = false;

        }

        public void OnNodeEnter(PlayerBehaviour playerBehaviour, Node node)
        {            
            AreaView.ShowArea(Range.Ring(node, range));            
        }

        public void OnNodeExit(PlayerBehaviour playerBehaviour, Node node)
        {
            //
        }

        public void OnNodePress(PlayerBehaviour playerBehaviour, Node node)
        {
            ThrowableAnimationCommand anim = animationFactory.Generate(playerBehaviour.position, node);
            AnimationInvoker.Enqueue(anim);

            if (node.occupant == null)
            {
                playerBehaviour.ExpendAction(this);
                return;
            }
            if (node.occupant.faction == targetFaction)
            {
                //doDamage(node.occupant);
                //animationFactory
                
                return;
            }
            return;
        }
    }
}