using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HoverPanelView : MonoBehaviour
{
    public Image imageUI;
    public GameObject hoverPanelGameobject;
    public TextMeshProUGUI titleUI;
    public TextMeshProUGUI descriptionUI;
    public TextMeshProUGUI hpUI;
    public Slider hpSlider;
    public static HoverPanelView instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static void Populate(AgentBase agentBase)
    {
        instance.imageUI.sprite = agentBase.visibleCharacter.sprite;
        instance.titleUI.text = agentBase.visibleCharacter.name;
        instance.descriptionUI.text = agentBase.Intent();
        instance.hpUI.text = agentBase.agent.hp.ToString() + " / " + agentBase.agent.maxHp.ToString();
        instance.hpSlider.maxValue = agentBase.agent.maxHp;
        instance.hpSlider.value = agentBase.agent.hp;

    }
    public static void Show(AgentBase agentBase)
    {
        Populate(agentBase);
        Show();
    }
    public static void Show()
    {
        instance.hoverPanelGameobject.SetActive(true);
    }
    public static void Hide()
    {
        instance.hoverPanelGameobject.SetActive(false);
    }
}
