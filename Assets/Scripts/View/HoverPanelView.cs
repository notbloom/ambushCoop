using Ambush;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoverPanelView : MonoBehaviour
{
    public static HoverPanelView instance;
    public TextMeshProUGUI descriptionUI;
    public GameObject hoverPanelGameobject;
    public Slider hpSlider;
    public TextMeshProUGUI hpUI;
    public Image imageUI;
    public TextMeshProUGUI titleUI;

    private void Start()
    {
        if (instance == null) instance = this;
    }

    public static void Populate(BoardAgent agent)
    {
        instance.imageUI.sprite = agent.boardSprite;
        instance.titleUI.text = agent.readableName;
        instance.descriptionUI.text = agent.Description();
        instance.hpUI.text = agent.currentHealth + " / " + agent.maxHealth;
        instance.hpSlider.maxValue = agent.maxHealth;
        instance.hpSlider.value = agent.currentHealth;
    }

    //deprecated
    // public static void Populate(AgentBase agentBase)
    // {
    //     instance.imageUI.sprite = agentBase.visibleCharacter.sprite;
    //     instance.titleUI.text = agentBase.visibleCharacter.name;
    //     instance.descriptionUI.text = agentBase.Intent();
    //     instance.hpUI.text = agentBase.agent.hp.ToString() + " / " + agentBase.agent.maxHp.ToString();
    //     instance.hpSlider.maxValue = agentBase.agent.maxHp;
    //     instance.hpSlider.value = agentBase.agent.hp;
    //
    // }
    public static void Show(BoardAgent agentBase)
    {
        Populate(agentBase);
        Show();
    }

    // public static void Show(AgentBase agentBase)
    // {
    //     Populate(agentBase);
    //     Show();
    // }
    public static void Show()
    {
        instance.hoverPanelGameobject.SetActive(true);
    }

    public static void Hide()
    {
        instance.hoverPanelGameobject.SetActive(false);
    }
}