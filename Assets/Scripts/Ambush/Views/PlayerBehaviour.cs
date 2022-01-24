using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ambush
{
    public class PlayerBehaviour : MonoBehaviour, IAgentBehaviour
    {
        //TODO Retrieve this from equipment?

        public List<IActionController> actions;
        public BoardPlayer boardAgent;

        public IActionController currentAction;

        //test
        public SimpleAttackFactory simpleAttackFactory;
        public Slider slider;
        public SpriteRenderer spriteRenderer;
        public Node position => boardAgent.position;

        public Transform Transform()
        {
            return transform;
        }

        public float CurrentHp()
        {
            return slider.value;
        }

        public void PlayTurn()
        {
        }

        public void ShowIntent()
        {
        }

        public void HideIntent()
        {
        }

        public void ShowHP(float hp)
        {
            slider.value = hp;
        }

        // Use this for initialization
        private void Awake()
        {
            // var saa = simpleAttackFactory.GenerateNew();
            // //currentAction = saa;
            // actions = new List<IActionController>();
            // actions.Add(saa);
        }

        private void Start()
        {
            if (slider != null)
            {
                slider.maxValue = boardAgent.maxHealth;
                slider.value = boardAgent.currentHealth;
            }
        }

        public void ProcessEquipment()
        {
            actions = new List<IActionController>();
            foreach (var item in boardAgent.equipment)
            foreach (var factory in item.actionFactories)
                actions.Add(factory.Generate());
        }

        // Update is called once per frame
        private void Update()
        {
        }

        internal void ActivateAction(IActionController actionController)
        {
            currentAction = actionController;
            currentAction.OnSkillActivate(this);
        }

        public void ExpendAction(IActionController actionController)
        {
            actionController.Cost();
            currentAction = null;
        }


        public void OnNodeEnter(Node node)
        {
            if (currentAction != null)
                currentAction.OnNodeEnter(this, node);
        }

        public void OnNodeExit(Node node)
        {
            if (currentAction != null)
                currentAction.OnNodeExit(this, node);
        }

        public void OnNodeClick(Node node)
        {
            if (currentAction != null)
                currentAction.OnNodePress(this, node);
        }


        internal void RequestTarget(int v, object singleTarget)
        {
            throw new NotImplementedException();
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
    }
}