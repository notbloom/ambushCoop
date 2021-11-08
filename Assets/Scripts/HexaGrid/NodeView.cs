using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using notbloom.HexagonalMap;
public class NodeView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public HNode node;
    private Renderer _renderer;
    private Color _defaultColor;

    public void Awake()
    {
        _renderer = gameObject.GetComponent<Renderer>();
    }

    public void SetDefaultColor(Color color) {
        _defaultColor = color;
        SetColor(color);
    }
    public void RestoreColor() => SetColor(_defaultColor);

    public void SetColor(Color color) {        
        MaterialPropertyBlock _propBlock = new MaterialPropertyBlock();        
        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetColor("_Color", color);
        _renderer.SetPropertyBlock(_propBlock);
    }
    public void OnPointerClick(PointerEventData e)
    {
        AreaView.OnNodeClick(node, this);
    }
    public void OnPointerEnter(PointerEventData e)
    {
        AreaView.OnNodeEnter(node, this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AreaView.OnNodeExit(node, this);
    }

    
}
