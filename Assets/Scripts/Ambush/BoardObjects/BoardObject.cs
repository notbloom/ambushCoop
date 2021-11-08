using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ambush
{
    [SerializeField]
    public class BoardObject
    {      
        public Node position;
        public Sprite boardSprite;
        public BoardFaction faction;
        public BoardObjectView view;
    }

    public class BoardLoot : BoardObject
    {


    }
    public class BoardTrigger : BoardObject
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
}