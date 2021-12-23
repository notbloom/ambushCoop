// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using notbloom.HexagonalMap;
// using System.Linq;
//
// public class GameLoader : MonoBehaviour
// {    
//     public void LoadScenario(string scenario_id = "test_scenario")
//     {
//         ScenarioData data = ScenarioData.Load(scenario_id);        
//         //Create Map
//         //HexagonalMapView.CreateMapFromNodeData(data.s_nodes);
//         HexagonalMapView.GenericMap();
//         //HexagonalMapView.Create(data);        
//         //Spawn Enemies
//         foreach (ObjectInstaceData objData in data.s_objects)
//         {
//             Debug.Log("Enemies/" + objData.string_id);
//             GameObject instance = Instantiate(Resources.Load("Enemies/" + objData.string_id, typeof(GameObject))) as GameObject;
//
//             ISpawn ispawn = instance.GetComponent<ISpawn>();
//             if (ispawn != null)
//                 ispawn.Spawn(objData);
//         }
//         //SpawnPlayers();
//     }
//     public void SaveScenario()
//     {
//         // Esta es la info q se enviaria si es q alguien se cae y relogea.
//         ScenarioData data = new ScenarioData();
//         //REGISTER NODES
//         data.string_id = "test_scenario";
//         data.s_nodes = new List<NodeData>();
//         foreach (HNode hnode in HexagonalMapView.MainMap.nodes)
//         {
//             data.s_nodes.Add(new NodeData(hnode));
//         }
//         //REGISTER OBJECTS
//         data.s_objects = new List<ObjectInstaceData>();
//         //OBJECTS -> ENEMY AGENTS
//         List<EnemyAgent> agentBases = GameObject.FindObjectsOfType<EnemyAgent>().ToList();
//         foreach (EnemyAgent agent in agentBases)
//         {
//             data.s_objects.Add(new ObjectInstaceData(agent));
//         }
//         ScenarioData.Save(data);
//     }
// }
