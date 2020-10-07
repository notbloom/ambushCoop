using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
public class HexagonalMapView : MonoBehaviour
{
    public GameObject hexPrefab;

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
        }
    }
    public static void CreateMapFromNodeData(List<NodeData> nodes)
    {
        instance.map = new HMap();
        instance.map.CreateFromNodeData(nodes);
        instance.GenerateView();
    }
}
