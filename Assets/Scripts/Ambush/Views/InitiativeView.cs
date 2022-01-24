using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ambush
{
    public class InitiativeView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public BoardAgent agentBase;
        public Image imageUI;
        public TextMeshProUGUI nameUI;
        public Image panelImageUI;

        public void OnPointerEnter(PointerEventData e)
        {
            HoverPanelView.Show(agentBase);
        }

        public void OnPointerExit(PointerEventData e)
        {
            HoverPanelView.Hide();
        }


        public void Populate(BoardAgent boardAgent)
        {
            agentBase = boardAgent;
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