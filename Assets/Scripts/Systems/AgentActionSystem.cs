//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using notbloom.HexagonalMap;
//public class AgentActionSystem : MonoBehaviour
//{
//    static AgentActionSystem instance;
//    public TurnSystem turnSystem;
//    public string localPlayerUniqueID;
//    public ScriptableAction playerSpawnAction;
//    void Start() {
//        if (instance == null) {
//            instance = this;
//        }
//    }
//    public void PlacePlayerOnSpawningNode(HNode spawnPoint) {

//        playerSpawnAction.PerformAction(null,
//        //new List<HNode>() { HexagonalMapView.MainMap.FindNodeByVector2Int(spawnPoint)},
//        new List<HNode>() { spawnPoint },
//        turnSystem.FindAgentBaseByID(localPlayerUniqueID));
//    }
//    public void RPCPlacePlayerOnSpawningNode(Vector2Int spawnPoint, string agent_id) { 

//    }
//    public void PlayerCardAction(string card_id, string player_id, Vector2Int node) { 

//    }
//    public void OnAgentPlayedCard() { 

//    }
//    public void OnAgentCancelledCard() { 

//    }
//    public void OnAgentClickedOnNode() { 

//    }
//}
