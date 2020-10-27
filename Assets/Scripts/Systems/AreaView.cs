using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;
//TODO remate to maybe PlayerUIController, PlayerViewController
public class AreaView : MonoBehaviour
{
    NodeView[] nodeViews;

    //public HNode node;
    public ScriptableCard card;
    public PlayerAgent playerAgent;
    private NodeView hoverNode;
    private static AreaView instance;

    public TurnSystem turnSystem;
    public AgentActionSystem agentActionSystem;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        nodeViews = FindObjectsOfType<NodeView>();
    }
    public static void OnCardActivate(ScriptableCard card)
    {
        instance.card = card;
    }
    public static void OnNodeClick(HNode node)
    {
        if (instance.turnSystem.CurrentPhase == TurnPhases.placingPlayers) {
            instance.agentActionSystem.PlacePlayerOnSpawningNode(node);
        }
        if (instance.turnSystem.CurrentPhase == TurnPhases.play)
        {
            if (instance.card != null)
            {
                instance.playerAgent.ClickOnNode(node, instance.card);
                instance.card = null;
            }
        }
    }

    public static void ResetView()
    {
        foreach (var item in instance.nodeViews)
        {
            MaterialPropertyBlock _propBlock = new MaterialPropertyBlock();
            Renderer _renderer = item.gameObject.GetComponent<Renderer>();
            _renderer.GetPropertyBlock(_propBlock);
            _propBlock.SetColor("_Color", Color.white);
            _renderer.SetPropertyBlock(_propBlock);
        }
    }
    public static void OnNodeEnter(HNode node)
    {

        if (instance.card != null)
        {

            //instance.card = instance.playerAgent.currentCard;
            List<HNode> n = new List<HNode>();
            //List<HNode> r = instance.card.Range(HexagonalMapView.finalNode, node);
            List<HNode> r = instance.card.Range(instance.playerAgent.agent.node);//, node);

            if (r.Contains(node))
            {
                //n = instance.card.Area(HexagonalMapView.finalNode, node);
                n = instance.card.Area(instance.playerAgent.agent.node, node);
            }


            foreach (var item in instance.nodeViews)
            {
                MaterialPropertyBlock _propBlock = new MaterialPropertyBlock();
                Renderer _renderer = item.gameObject.GetComponent<Renderer>();

                // Get the current value of the material properties in the renderer.
                _renderer.GetPropertyBlock(_propBlock);
                // Assign our new value.
                _propBlock.SetColor("_Color", Color.white);
                // Apply the edited values to the renderer.
                _renderer.SetPropertyBlock(_propBlock);

                if (r.Contains(item.node))
                {
                    _propBlock.SetColor("_Color", Color.magenta);
                    // Apply the edited values to the renderer.
                    _renderer.SetPropertyBlock(_propBlock);
                }
                if (n.Contains(item.node))
                {
                    _propBlock.SetColor("_Color", Color.cyan);
                    // Apply the edited values to the renderer.
                    _renderer.SetPropertyBlock(_propBlock);
                }
            }
        }
        else
        {
            //When no card is selected
            if (instance.hoverNode != null)
            {
                MaterialPropertyBlock __propBlock = new MaterialPropertyBlock();
                Renderer __renderer = instance.hoverNode.gameObject.GetComponent<Renderer>();
                __renderer.GetPropertyBlock(__propBlock);
                __propBlock.SetColor("_Color", Color.white);
                __renderer.SetPropertyBlock(__propBlock);
            }
            MaterialPropertyBlock _propBlock = new MaterialPropertyBlock();
            instance.hoverNode = instance.nodeViews.Where(x => x.node == node).First();
            Renderer _renderer = instance.hoverNode.gameObject.GetComponent<Renderer>();

            _renderer.GetPropertyBlock(_propBlock);
            _propBlock.SetColor("_Color", Color.blue);
            _renderer.SetPropertyBlock(_propBlock);
        }
    }
    public static void ShowStartingPoints(List<HNode> startingNodes)
    {
        foreach (NodeView nodeView in instance.nodeViews)
        {
            if (startingNodes.Contains(nodeView.node))
            {
                MaterialPropertyBlock _propBlock = new MaterialPropertyBlock();
                Renderer _renderer = nodeView.gameObject.GetComponent<Renderer>();

                // Get the current value of the material properties in the renderer.
                _renderer.GetPropertyBlock(_propBlock);
                // Assign our new value.
                _propBlock.SetColor("_Color", Color.blue);
                // Apply the edited values to the renderer.
                _renderer.SetPropertyBlock(_propBlock);
            }
        }

    }    // Update is called once per frame
    public static void UpdateView(HNode node)
    {
        //TODO make an input controller system


    }
}
