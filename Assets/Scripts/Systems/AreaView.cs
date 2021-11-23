using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;
using Ambush;

// TODO maybe a system that grabs Node Lists, a color and priority and displays them.

public class AreaView : MonoBehaviour
{
    NodeView[] nodeViews;
    Dictionary<Node, NodeView> nodeViewsDict; //usar esto mejor para mostrar cosas
    //public Node node;
    public ScriptableCard card;
    public PlayerBehaviour playerBehaviour;
    private NodeView hoverNode;
    private static AreaView instance;

    public TurnSystem turnSystem;
    public AgentActionSystem agentActionSystem;

    private List<Node> areaNodes;
    private List<Node> rangeNodes;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Init()
    {
        nodeViews = FindObjectsOfType<NodeView>(); //cambiar a temporal o cambiar este init.
        nodeViewsDict = new Dictionary<Node, NodeView>();
        foreach (NodeView nv in nodeViews) {
            nodeViewsDict.Add(nv.node, nv);
        }
        areaNodes = new List<Node>();
        rangeNodes = new List<Node>(); 
    }
    public static void OnCardActivate(ScriptableCard card)
    {
        instance.card = card;
    }
    public static void OnNodeClick(Node node, NodeView nodeView)
    {
        instance.playerBehaviour.OnNodeClick(node);
    }

    public static void OnNodeEnter(Node node, NodeView nodeView)
    {
        instance.playerBehaviour.OnNodeEnter(node);

        nodeView.SetColor(Color.cyan);
        if (node.occupant is BoardAgent) {
            HoverPanelView.Populate((BoardAgent)node.occupant);
        }
    }
    public static void OnNodeExit(Node node, NodeView nodeView)
    {
        instance.playerBehaviour.OnNodeExit(node);
        nodeView.RestoreColor();
    }

    public static void ResetView()
    {
        foreach (var item in instance.nodeViewsDict)
        {
            item.Value.RestoreColor();
        }
        foreach (var node in instance.rangeNodes)
        {
            instance.nodeViewsDict[node].SetColor(Color.green);
        }
        foreach (var node in instance.areaNodes)
        {
            instance.nodeViewsDict[node].SetColor(Color.magenta);
        }
    }
    public static void ShowArea(List<Node> areaNodes) {

        instance.areaNodes = areaNodes;
        //foreach (var node in areaNodes)
        //{
        //    instance.nodeViewsDict[node].SetColor(Color.green);
        //}
        ResetView();
    }
    public static void HideArea(List<Node> areaNodes = null) {
        instance.areaNodes = new List<Node>();
    }
    public static void ShowRange(List<Node> rangeNodes)
    {
        instance.rangeNodes = rangeNodes;
        ResetView();

        //foreach (var node in areaNodes)
        //{
        //    instance.nodeViewsDict[node].SetColor(Color.green);
        //}
    }
    public static void HideRange(List<Node> areaNodes = null)
    {
        instance.rangeNodes = new List<Node>();
    }
    public static void ShowStartingPoints(List<Node> startingNodes)
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
    public static void UpdateView(Node node)
    {
        //TODO make an input controller system


    }
}
