using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Ambush
{
    public class PlayerBehaviour : MonoBehaviour, IAgentBehaviour
    {
        public SpriteRenderer spriteRenderer;        
        public BoardPlayer boardAgent;
        public Slider slider;
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

        void Start()
        {
            if (slider != null)
            {
                slider.maxValue = boardAgent.maxHealth;
                slider.value = boardAgent.currentHealth;
            }
        }

        public float CurrentHp() => slider.value;

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

        public void ShowHP(float hp)
        {
            
            slider.value = hp;
            
        }


        internal void RequestTarget(int v, object singleTarget)
        {
            throw new NotImplementedException();
        }
    }

}