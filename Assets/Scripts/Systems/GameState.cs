using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnState{
    public string[] orderedIDs;
    public short currentTurn;
}
public class EnemyState {
    public string scene_id;
    public string type_id;
    public short[] statusIDs;
    public short turn;
    public short current_hp;
    public Vector2Int position;
}
public class PlayerState {
    public string playerName;
    public string player_id;
    public Vector2Int position;
}
public class GameState : MonoBehaviour
{
    public string scenario_id = "scenario_id";
    public List<Object> objects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
