using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using notbloom.HexagonalMap;
public class NodeView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public HNode node;
    public ScriptableAOE aoe;
    public void OnPointerClick(PointerEventData e)
    {
        HexagonalMapView.finalNode = node;
    }
    public void OnPointerEnter(PointerEventData e)
    {
        AreaView.UpdateView(node);
        // List<HNode> n = aoe.Area.Targets(HexagonalMapView.finalNode, node);
        // List<HNode> r = new List<HNode>();
        // if (n.Contains(node))
        // {
        //     r = aoe.Range.Targets(HexagonalMapView.finalNode, node);
        // }

        // NodeView[] nodeViews = FindObjectsOfType<NodeView>();
        // foreach (var item in nodeViews)
        // {
        //     MaterialPropertyBlock _propBlock = new MaterialPropertyBlock();
        //     Renderer _renderer = item.gameObject.GetComponent<Renderer>();

        //     // Get the current value of the material properties in the renderer.
        //     _renderer.GetPropertyBlock(_propBlock);
        //     // Assign our new value.
        //     _propBlock.SetColor("_Color", Color.white);
        //     // Apply the edited values to the renderer.
        //     _renderer.SetPropertyBlock(_propBlock);

        //     if (r.Contains(item.node))
        //     {
        //         _propBlock.SetColor("_Color", Color.magenta);
        //         // Apply the edited values to the renderer.
        //         _renderer.SetPropertyBlock(_propBlock);
        //     }
        //     if (n.Contains(item.node))
        //     {
        //         _propBlock.SetColor("_Color", Color.cyan);
        //         // Apply the edited values to the renderer.
        //         _renderer.SetPropertyBlock(_propBlock);
        //     }
        // }

    }
}
