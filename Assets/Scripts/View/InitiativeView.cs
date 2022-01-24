using Ambush;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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


    public void Populate(BoardAgent agentBase)
    {
        this.agentBase = agentBase;
        imageUI.sprite = agentBase.boardSprite;
        nameUI.text = agentBase.readableName;
    }

    public void OnTurnStart()
    {
        panelImageUI.color = Color.cyan;
    }

    public void OnTurnEnd()
    {
        panelImageUI.color = Color.blue;
    }
}