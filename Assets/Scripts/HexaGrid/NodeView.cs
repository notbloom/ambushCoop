using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using notbloom.HexagonalMap;
public class NodeView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public HNode node;
    public void OnPointerClick(PointerEventData e)
    {
        HexagonalMapView.finalNode = node;
    }
    public void OnPointerEnter(PointerEventData e)
    {
        //Debug.Log(node.ToStringWithNeighbours());

        List<HNode> n = HPathFinder.GetShortestPathDijkstra(node, HexagonalMapView.finalNode);
        NodeView[] nodeViews = FindObjectsOfType<NodeView>();
        foreach (var item in nodeViews)
        {
            MaterialPropertyBlock _propBlock = new MaterialPropertyBlock();
            Renderer _renderer = item.gameObject.GetComponent<Renderer>();

            // Get the current value of the material properties in the renderer.
            _renderer.GetPropertyBlock(_propBlock);
            // Assign our new value.
            _propBlock.SetColor("_Color", Color.white);
            // Apply the edited values to the renderer.
            _renderer.SetPropertyBlock(_propBlock);

            if (n.Contains(item.node))
            {

                _propBlock.SetColor("_Color", Color.cyan);
                // Apply the edited values to the renderer.
                _renderer.SetPropertyBlock(_propBlock);


            }
        }

    }
}
