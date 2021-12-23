using System.Collections;
using System.Collections.Generic;
using Ambush;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InitiativeView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image imageUI;
    public Image panelImageUI;
    public TextMeshProUGUI nameUI;
    public BoardAgent agentBase;

    public void OnPointerEnter(PointerEventData e) => HoverPanelView.Show(agentBase);
    public void OnPointerExit(PointerEventData e) => HoverPanelView.Hide();


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
