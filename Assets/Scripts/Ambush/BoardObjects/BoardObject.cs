using UnityEngine;
using System.Collections;

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
}