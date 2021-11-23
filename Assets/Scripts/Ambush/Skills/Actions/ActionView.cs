using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Ambush{
    public class ActionView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Image imageUI;
        public Image panelImageUI;
        public TextMeshProUGUI nameUI;
        public PlayerBehaviour playerBehaviour;
        public IActionController actionController;

        public void OnPointerEnter(PointerEventData e) => actionController.OnSkillHover(playerBehaviour);
        public void OnPointerExit(PointerEventData e) => actionController.OnSkillExitHover(playerBehaviour);
        public void OnPointerClick(PointerEventData e)
        {
            playerBehaviour.ActivateAction(actionController);
        }
        void Start()
        {
            SimpleAttackAction saa = new SimpleAttackAction();
            actionController = saa;
        }
        public void Populate(PlayerBehaviour playerBehaviour, IActionController actionController)
        {
            this.playerBehaviour = playerBehaviour;
            this.actionController = actionController;
            
        }
        public void OnTurnStart()
        {
            panelImageUI.color = Color.blue;
            //panelImageUI.color = agentBase.visibleCharacter.initiativeColorOnTurn;
        }
        public void OnTurnEnd()
        {
            panelImageUI.color = Color.grey;
            //panelImageUI.color = agentBase.visibleCharacter.initiativeColorOffTurn;
        }

        
    }

}