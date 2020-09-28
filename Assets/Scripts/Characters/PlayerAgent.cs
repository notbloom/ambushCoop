using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
public class PlayerAgent : MonoBehaviour
{
    public ScriptableAgent agent;
    public SpriteRenderer spriteRenderer;

    public List<ScriptableCard> actions;

    public int actionCount = 0;

    public HNode node;
    public ScriptableCard currentCard => actions[actionCount];
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = agent.visibleCharacter.sprite;
        agent.node = HexagonalMapView.MainMap.nodes[UnityEngine.Random.Range(0, HexagonalMapView.MainMap.nodes.Count)];
        agent.node.occupant = agent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(agent.node.x, 0, agent.node.y);
    }
    public void ClickOnNode(HNode node)
    {

        PerformAction(actions[actionCount], new List<HNode>() { node });
        actionCount++;
        if (actionCount == actions.Count)
            actionCount = 0;
    }
    public void PerformAction(ScriptableCard action, List<HNode> targets)
    {
        action.PerformAction(agent.node, targets);
    }
}
