using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Codice.CM.Common;

namespace Ambush
{
    
    public class MoveActionController : IActionController
    {
        [SerializeField]
        public int steps = 2;
        
        //Clickeao en la barra
        private bool active = false;
        
        public MoveAnimationFactory animationFactory;

        public int Cost() => steps;

        public void ApplyAction()
        {
            //calcute damg
        }

        public void OnSkillHover(PlayerBehaviour playerBehaviour)
        {
            // SHOW RANGE
            Debug.Log(playerBehaviour.position.ToString());
            AreaView.ShowRange(Range.Walkable(playerBehaviour.position,steps,playerBehaviour.boardAgent.faction));
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

        public void OnSkillActivate(PlayerBehaviour playerBehaviour)
        {
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
            AreaView.ShowArea(Area.Path(playerBehaviour.position, node, steps));
            
        }

        public void OnNodeExit(PlayerBehaviour playerBehaviour, Node node)
        {
         
        }

        public void OnNodePress(PlayerBehaviour playerBehaviour, Node node)
        {
            MoveAnimationCommand anim = animationFactory.Generate(playerBehaviour.boardAgent, node);
            // foreach (var item in collection)
            // {
            //     por cada paso crear una anim
            // }
            AnimationInvoker.Enqueue(anim);

            if (node.occupant == null){

            }

        }
        
    }
}