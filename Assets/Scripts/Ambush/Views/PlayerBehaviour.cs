using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Ambush
{
    public class PlayerBehaviour : MonoBehaviour, IAgentBehaviour
    {
        public SpriteRenderer spriteRenderer;        
        public BoardPlayer boardAgent;
        public Node position => boardAgent.position;
        public Transform Transform() => transform;

        //TODO Retrieve this from equipment?
        
        public List<IActionController> actions;

        public IActionController currentAction;

        //test
        public SimpleAttackFactory simpleAttackFactory;

        // Use this for initialization
        void Awake()
        {
            // var saa = simpleAttackFactory.GenerateNew();
            // //currentAction = saa;
            // actions = new List<IActionController>();
            // actions.Add(saa);
        }

        public void ProcessEquipment(){
            actions = new List<IActionController>();
            foreach (Equipment item in boardAgent.equipment)
            {
                foreach (ActionFactory factory in item.actionFactories)
                {
                    actions.Add(factory.Generate());
                }                
            }
            
        }
        // Update is called once per frame
        void Update()
        {

        }

        public void PlayTurn(){

        }
        public void ShowIntent()
        {

        }

        internal void ActivateAction(IActionController actionController)
        {
            currentAction = actionController;
            currentAction.OnSkillActivate(this);
        }

        public void ExpendAction(IActionController actionController) {
            actionController.Cost();
            currentAction = null;
        }


        public void OnNodeEnter(Node node)
        {
            if (currentAction != null)
                currentAction.OnNodeEnter(this, node);
        }
        public void OnNodeExit(Node node) {
            if (currentAction != null)
                currentAction.OnNodeExit(this, node);
        }
        
        public void OnNodeClick(Node node)
        {
            if (currentAction != null)
                currentAction.OnNodePress(this, node);
        }

        #region Area & Range

        internal void ShowRange(List<Node> rangeNodes)
        {
            // UI SHOW RANGE NODES
        }

    

        internal void ResetRange()
        {
            // UI CLEAN UP
           // throw new NotImplementedException();
        }
        internal void ShowArea(List<Node> rangeNodes)
        {
            // UI SHOW RANGE NODES
        }

        internal void ResetArea()
        {
            // UI CLEAN UP
            // throw new NotImplementedException();
        }

        #endregion

        public void HideIntent()
        {

        }
        



        internal void RequestTarget(int v, object singleTarget)
        {
            throw new NotImplementedException();
        }
    }

}