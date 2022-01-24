using UnityEngine;

namespace Ambush
{
    [SerializeField]
    public class BoardObject
    {
        public Sprite boardSprite;
        public BoardFaction faction;
        public Node position;
        public IAgentBehaviour view;
    }
}