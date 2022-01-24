using System.Collections.Generic;
using UnityEngine;

namespace Ambush
{
    public class BoardView : MonoBehaviour
    {
        public const float innerRadius = 3f;
        public const float outerRadius = 0.866025404f;
        public static BoardView instance;
        public AreaView areaView;
        private Board board;
        public GameObject hexPrefab;
        public List<Color> tileColors;
        public static Map MainMap => instance.board.map;

        private void Awake()
        {
            if (instance == null) instance = this;
        }

        public void Load(Board board)
        {
            GenerateMapView(board.map);
            areaView.Init();
        }

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void GenerateMapView(Map map)
        {
            foreach (var node in map.nodes)
            {
                var hexCell = Instantiate(hexPrefab, node.ToVector3(), Quaternion.identity);
                hexCell.transform.parent = transform;
                var nodeView = hexCell.GetComponent<NodeView>();
                nodeView.node = node;
                //finalNode = node;

                if (map.startingNodes.Contains(node))
                    nodeView.SetDefaultColor(Color.blue);
                else
                    nodeView.SetDefaultColor(tileColors[Random.Range(0, tileColors.Count - 1)]);

                //MaterialPropertyBlock _propBlock = new MaterialPropertyBlock();
                //Renderer _renderer = hexCell.GetComponent<Renderer>();


                //_renderer.GetPropertyBlock(_propBlock);
                //if (map.startingNodes.Contains(node))
                //{
                //    _propBlock.SetColor("_Color", Color.blue);
                //}
                //else
                //{
                //    _propBlock.SetColor("_Color", tileColors[Random.Range(0, tileColors.Count - 1)]);
                //}
                //_renderer.SetPropertyBlock(_propBlock);
            }
        }

        //public static Node FindNodeByData(NodeData nodeData)
        //{
        //    return instance.map.nodes.Where(n => n.x == nodeData.x && n.y == nodeData.y).First();
        //}
        //public static void CreateMapFromNodeData(List<NodeData> nodes)
        //{
        //    instance.map = new HMap();
        //    instance.map.CreateFromNodeData(nodes);
        //    instance.GenerateView();
        //}
        //public static void Create(ScenarioData scenarioData)
        //{
        //    instance.map = new HMap();
        //    instance.map.CreateFromNodeData(scenarioData.s_nodes);
        //    instance.map.SetStartingNodes(scenarioData.s_starting_nodes);
        //    instance.GenerateView();
        //}
    }
}