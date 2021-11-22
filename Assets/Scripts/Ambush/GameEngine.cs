using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ambush
{
    public enum GameEngineState{
        Loading,
        Placing,
        Playing,
        Victory,
        Defeat
    }
    public class GameEngine : MonoBehaviour{
        public Board board;
        public BoardView boardView;
        public TurnSystem turnSystem;
        public AnimationSystem animationSystem;
        // Start is called before the first frame update
        void Start()
        {
            CreateGeneric();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void CreateGeneric()
        {
            board.CreateGeneric();
            boardView.Load(board);//Cambiar por Display? algo para iniciar la vista
            //SpawnPlayers();
            //turnSystem
        }
        //public void SaveScenario()
        //{
        //    // Esta es la info q se enviaria si es q alguien se cae y relogea.
        //    ScenarioData data = new ScenarioData();
        //    //REGISTER NODES
        //    data.string_id = "test_scenario";
        //    data.s_nodes = new List<NodeData>();
        //    foreach (HNode hnode in HexagonalMapView.MainMap.nodes)
        //    {
        //        data.s_nodes.Add(new NodeData(hnode));
        //    }
        //    //REGISTER OBJECTS
        //    data.s_objects = new List<ObjectInstaceData>();
        //    //OBJECTS -> ENEMY AGENTS
        //    List<EnemyAgent> agentBases = GameObject.FindObjectsOfType<EnemyAgent>().ToList();
        //    foreach (EnemyAgent agent in agentBases)
        //    {
        //        data.s_objects.Add(new ObjectInstaceData(agent));
        //    }
        //    ScenarioData.Save(data);
        //}
    }
}