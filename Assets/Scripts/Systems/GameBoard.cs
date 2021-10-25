using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ambush
{
    public class BoardObject
    {
        public Node Position;
        public Sprite BoardSprite;
    }

    public class BoardMap
    {
        public List<Node> nodes;
        public void Create();
        public bool isNodeOccupied(Node node) => node.piece != null;
        
    }
    public class Node
    {
        public ushort x;
        public ushort y;
        public BoardPiece piece;
    }
    
    public class BoardPiece : BoardObject
    {
        
    }
    public class BoardLoot : IBoardObject
    {
        
        
    }
    public class BoardTrigger : IBoardObject{
        public Sprite BoardSprite() => null;
        public Node Position() => null;
    }
    public class IBoardAgent : IBoardObject
    {
        public Node node;
        public Node Position() => node;
        public Sprite BoardSprite() => null;
        public string unique_id;
        public void Spawn() { }
        public ushort initiative;
    }
    public class BoardPlayer : BoardAgent
    {
        
    }
    public class BoardEnemey : BoardAgent
    {

    }
    public class Turns
    {
        public enum Phase { spawning, playing, rewards }
        public Phase phase;
        public BoardAgent currentAgent;
        public int scenarioInitiative;
        public Queue<BoardAgent> QueueAgents(List<BoardAgent> boardAgents)
        {
            return new Queue<BoardAgent>(boardAgents.OrderBy(agent => agent.initiative));

        }
    }

    public class Board
    {
        public BoardMap boardMap;
        public List<BoardPlayer> boardPlayers;
        public List<BoardEnemey> boardEnemies;
        public BoardPlayer Player(string id) { return null; }
        public void Agents() { }
        public void Object() { }
        public void Turn() { }
    }
}