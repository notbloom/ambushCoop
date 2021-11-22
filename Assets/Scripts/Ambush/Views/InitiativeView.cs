using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Ambush{
    public class InitiativeView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image imageUI;
        public Image panelImageUI;
        public TextMeshProUGUI nameUI;
        public BoardAgent agentBase;

        public void OnPointerEnter(PointerEventData e) => HoverPanelView.Show(agentBase);
        public void OnPointerExit(PointerEventData e) => HoverPanelView.Hide();


        public void Populate(BoardAgent boardAgent)
        {
            this.agentBase = boardAgent;
            imageUI.sprite = boardAgent.boardSprite;
            nameUI.text = boardAgent.readableName;
            
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