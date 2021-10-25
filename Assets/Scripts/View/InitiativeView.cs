using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InitiativeView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image imageUI;
    public Image panelImageUI;
    public TextMeshProUGUI nameUI;
    public AgentBase agentBase;

    public void OnPointerEnter(PointerEventData e) => HoverPanelView.Show(agentBase);
    public void OnPointerExit(PointerEventData e) => HoverPanelView.Hide();


    public void Populate(AgentBase agentBase)
    {
        this.agentBase = agentBase;
        imageUI.sprite = agentBase.visibleCharacter.sprite;
        nameUI.text = agentBase.visibleCharacter.name;
    }
    public void OnTurnStart()
    {
        panelImageUI.color = agentBase.visibleCharacter.initiativeColorOnTurn;
    }
    public void OnTurnEnd()
    {
        panelImageUI.color = agentBase.visibleCharacter.initiativeColorOffTurn;
    }
}
