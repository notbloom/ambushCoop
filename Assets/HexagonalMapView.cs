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
        // }
        // void Start()
        // {
        map = new HMap();
        map.CreateSimpleGrid(rows, cols);
        foreach (HNode node in map.nodes)
        {
            GameObject hexCell = Instantiate(hexPrefab, new Vector3(node.x, 0, node.y), Quaternion.identity);
            hexCell.transform.parent = transform;
            NodeView nodeView = hexCell.GetComponent<NodeView>();
            nodeView.node = node;
            finalNode = node;
        }
    }
}
