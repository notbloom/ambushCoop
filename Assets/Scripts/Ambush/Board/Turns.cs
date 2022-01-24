using System.Collections.Generic;
using System.Linq;

namespace Ambush
{
    public class Turns
    {
        public BoardAgent currentAgent;
        public Phase phase;
        public int scenarioInitiative;

        public Queue<BoardAgent> QueueAgents(List<BoardAgent> boardAgents)
        {
            return new Queue<BoardAgent>(boardAgents.OrderBy(agent => agent.initiative));
        }
    }
}