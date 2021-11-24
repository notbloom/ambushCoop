using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using UnityEngine.UI;
[RequireComponent(typeof(SpriteRenderer))]

//TODO rename to AgentBaseView or similar. AgentSkin?
public class AgentID {
    public string type_id;
    public ushort number_id;
    public string unique_id => type_id + "-"+ number_id.ToString();

    public AgentID(string uniqueString) {
        string[] split = uniqueString.Split( new char[] {'-'});
        type_id = split[0];
        number_id = ushort.Parse(split[1]);
    }
}
public abstract class AgentBase : MonoBehaviour
{
    public string string_id;
    public AgentID agentID;
    public VisibleObject visibleCharacter;
    public BaseStats baseStats;
    public HObjectFactions faction;
    public Agent agent;
    public SpriteRenderer spriteRenderer;
    public int actionCount = 0;
    public int initiative;
    public Slider slider;
    public HNode node { get { return agent.node; } set { agent.node = value; } }

    public void Create()
    {
        agent = new Agent();
        agent.faction = faction;
        agent.baseStats = baseStats;
        ShowSprite();
        
        if (slider != null)
        {
            slider.maxValue = agent.maxHp;
            slider.value = agent.maxHp;
            agent.ReceiveDamageCall += PostReceiveDamage;
        }        
    }
    public void Init(ObjectInstaceData objectInstaceData)
    {
        agent = new Agent();
        agent.faction = faction;
        agent.baseStats = baseStats;
        ShowSprite();
        node = HexagonalMapView.FindNodeByData(objectInstaceData.node);
        //node = HexagonalMapView.MainMap.nodes[UnityEngine.Random.Range(0, HexagonalMapView.MainMap.nodes.Count)];
        node.occupant = agent;

        if (slider != null)
        {
            slider.maxValue = agent.maxHp;
            slider.value = agent.maxHp;
            agent.ReceiveDamageCall += PostReceiveDamage;
        }        
    }
    public void Init(HNode node)
    {
        agent = new Agent();
        agent.faction = faction;
        agent.baseStats = baseStats;
        ShowSprite();
        //node = HexagonalMapView.FindNodeByData(node);
        //node = HexagonalMapView.MainMap.nodes[UnityEngine.Random.Range(0, HexagonalMapView.MainMap.nodes.Count)];
        node.occupant = agent;

        if (slider != null)
        {
            slider.maxValue = agent.maxHp;
            slider.value = agent.maxHp;
            agent.ReceiveDamageCall += PostReceiveDamage;
        }
    }
    public void ShowSprite()
    {
        spriteRenderer.sprite = visibleCharacter.sprite;
    }
    public void PostReceiveDamage(HDamageInstance damageInstance)
    {
//        AnimationInvoker.Enqueue(new ReceiveDamageAnimationCommand(this, agent.hp, 0.2f));
        if (agent.hp <= 0)
        {
            Debug.Log("DEAD?");
 //           AnimationInvoker.Enqueue(new DestroyGameobjectCommand(gameObject));
            TurnSystem.RemoveAgent(this);
        }
        //agent.hp -= damageInstance.amount;
        //UpdateView();
    }
    public abstract void PlayTurn();
    public abstract string Intent();
}

//TODO make their own file
public class DestroyGameobjectCommand : AnimationCommand
{
    GameObject target;
    public DestroyGameobjectCommand(GameObject target)
    {
        this.target = target;
    }
    public override IEnumerator Animate()
    {
        GameObject.Destroy(target);
        Debug.Log("DESTROY");
        return null;
    }
}
public class ReceiveDamageAnimationCommand : AnimationCommand
{
    public float animationTime;
    public AgentBase agent;
    public float startTime;
    public float startingHp;
    public float endingHp;
    public ReceiveDamageAnimationCommand(AgentBase agent, float endingHp, float animationTime)
    {
        this.agent = agent;
        this.endingHp = endingHp;
        this.animationTime = animationTime;
    }
    public override IEnumerator Animate()
    {
        startingHp = agent.slider.value;
        startTime = Time.time;
        yield return _Animate();
    }
    private IEnumerator _Animate()
    {
        while (Time.time < startTime + animationTime)
        {
            agent.slider.value = Mathf.Lerp(startingHp, endingHp, (Time.time - startTime) / animationTime);
            //agent.UpdateView();
            yield return null;
        }
        //TODO change this math to agent damage processing
        agent.slider.value = endingHp;
        //agent.UpdateView();
    }

}