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
        AreaView.OnNodeClick(node);
    }
    public void OnPointerEnter(PointerEventData e)
    {
        AreaView.OnNodeEnter(node);
    }
}
