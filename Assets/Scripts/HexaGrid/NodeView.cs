using Ambush;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Color _defaultColor;
    private Renderer _renderer;
    public Node node;

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

    public void Awake()
    {
        _renderer = gameObject.GetComponent<Renderer>();
    }

    public void SetDefaultColor(Color color)
    {
        _defaultColor = color;
        SetColor(color);
    }

    public void RestoreColor()
    {
        SetColor(_defaultColor);
    }

    public void SetColor(Color color)
    {
        var _propBlock = new MaterialPropertyBlock();
        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetColor("_Color", color);
        _renderer.SetPropertyBlock(_propBlock);
    }
}