using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using UnityEngine.UI;
[RequireComponent(typeof(SpriteRenderer))]
public abstract class AgentBase : MonoBehaviour
{
    public VisibleObject visibleCharacter;
    public HObjectFactions faction;
    public Agent agent;
    public SpriteRenderer spriteRenderer;
    public int actionCount = 0;

    public Slider slider;
    public HNode node { get { return agent.node; } set { agent.node = value; } }

    public void Init()
    {
        agent = new Agent();
        agent.faction = faction;
        spriteRenderer.sprite = visibleCharacter.sprite;
        node = HexagonalMapView.MainMap.nodes[UnityEngine.Random.Range(0, HexagonalMapView.MainMap.nodes.Count)];
        node.occupant = agent;

        if (slider != null)
        {
            slider.maxValue = agent.maxHp;
            slider.value = agent.maxHp;
            agent.UpdateView += UpdateView;
        }
    }
    public void ReceiveDamage(HDamageInstance damageInstance)
    {
        agent.hp -= damageInstance.amount;
        UpdateView();
    }
    public abstract void PlayTurn();

    public void UpdateView()
    {
        slider.value = agent.hp;
    }
}
