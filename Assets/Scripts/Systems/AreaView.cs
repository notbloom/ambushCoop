using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
public class AreaView : MonoBehaviour
{
    NodeView[] nodeViews;

    //public HNode node;
    public ScriptableCard card;
    public PlayerAgent playerAgent;
    private static AreaView instance;
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

    public static void OnNodeClick(HNode node)
    {
        // instance.card = instance.playerAgent.currentCard;
        // List<HNode> n = new List<HNode>();
        // //List<HNode> r = instance.card.Range(HexagonalMapView.finalNode, node);
        // List<HNode> r = instance.card.Range(instance.playerAgent.agent.node, node);

        // if (r.Contains(node))
        // {
        //     //n = instance.card.Area(HexagonalMapView.finalNode, node);
        //     n = instance.card.Area(instance.playerAgent.agent.node, node);
        // }

        instance.playerAgent.ClickOnNode(node);
    }

    public static void OnNodeEnter(HNode node)
    {
        instance.card = instance.playerAgent.currentCard;
        List<HNode> n = new List<HNode>();
        //List<HNode> r = instance.card.Range(HexagonalMapView.finalNode, node);
        List<HNode> r = instance.card.Range(instance.playerAgent.agent.node, node);

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
    // Update is called once per frame
    public static void UpdateView(HNode node)
    {
        //TODO make an input controller system


    }
}
