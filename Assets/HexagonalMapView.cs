using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;
public class HexagonalMapView : MonoBehaviour
{
    public GameObject hexPrefab;
    public List<Color> tileColors;
    public const float innerRadius = 3f;
    public const float outerRadius = 0.866025404f;
    public int rows;
    public int cols;
    private HMap map;
    public static HexagonalMapView instance;
    public static HMap MainMap => instance.map;
    public static HNode finalNode;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public static void GenericMap()
    {
        instance.map = new HMap();
        instance.map.CreateSimpleGrid(instance.rows, instance.cols);
        //map.Save();
        instance.GenerateView();
    }
    public void GenerateView()
    {
        foreach (HNode node in map.nodes)
        {
            GameObject hexCell = Instantiate(hexPrefab, node.ToVector3(), Quaternion.identity);
            hexCell.transform.parent = transform;
            NodeView nodeView = hexCell.GetComponent<NodeView>();
            nodeView.node = node;
            finalNode = node;

            

             MaterialPropertyBlock _propBlock = new MaterialPropertyBlock();
                Renderer _renderer = hexCell.GetComponent<Renderer>();

                // Get the current value of the material properties in the renderer.
                _renderer.GetPropertyBlock(_propBlock);
                // Assign our new value.
                _propBlock.SetColor("_Color", tileColors[Random.Range(0, tileColors.Count - 1)]);
                // Apply the edited values to the renderer.
                _renderer.SetPropertyBlock(_propBlock);
        }
    }
    public static HNode FindNodeByData(NodeData nodeData)
    {
        return instance.map.nodes.Where(n => n.x == nodeData.x && n.y == nodeData.y).First();
    }
    public static void CreateMapFromNodeData(List<NodeData> nodes)
    {
        instance.map = new HMap();
        instance.map.CreateFromNodeData(nodes);
        instance.GenerateView();
    }
}
