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

        // for (int i = 0; i < rows; i++)
        // {
        //     for (int j = 0; j < cols; j++)
        //     {
        //         Vector3 position;
        //         if (j % 2 == 0)
        //         {
        //             position = new Vector3(i * innerRadius, 0, j * outerRadius);
        //         }
        //         else
        //         {
        //             position = new Vector3(i * innerRadius + innerRadius / 2f, 0, j * outerRadius);
        //         }
        //         GameObject hexCell = Instantiate(hexPrefab, position, Quaternion.identity);
        //         hexCell.transform.parent = transform;
        //     }
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
