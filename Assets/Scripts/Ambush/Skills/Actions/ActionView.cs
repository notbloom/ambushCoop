using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ambush
{
    public class ActionView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] public IActionController actionController;

        public Image imageUI;
        public TextMeshProUGUI nameUI;
        public Image panelImageUI;
        public PlayerBehaviour playerBehaviour;

        public void OnPointerClick(PointerEventData e)
        {
            playerBehaviour.ActivateAction(actionController);
        }

        public void OnPointerEnter(PointerEventData e)
        {
            actionController.OnSkillHover(playerBehaviour);
        }

        public void OnPointerExit(PointerEventData e)
        {
            actionController.OnSkillExitHover(playerBehaviour);
        }

        public void Populate(PlayerBehaviour playerBehaviour, IActionController actionController)
        {
            this.playerBehaviour = playerBehaviour;
            this.actionController = actionController;
            imageUI.sprite = actionController.UISprite();
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