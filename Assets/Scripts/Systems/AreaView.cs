using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
public class AreaView : MonoBehaviour
{
    NodeView[] nodeViews;

    //public HNode node;
    public ScriptableAOE aoe;
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

    // Update is called once per frame
    public static void UpdateView(HNode node)
    {
        List<HNode> n = new List<HNode>();
        List<HNode> r = instance.aoe.Range.Targets(HexagonalMapView.finalNode, node);
        if (r.Contains(node))
        {
            n = instance.aoe.Area.Targets(HexagonalMapView.finalNode, node);
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
}
