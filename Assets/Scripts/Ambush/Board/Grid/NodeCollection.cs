using System.Collections.Generic;
using UnityEngine;

namespace Ambush
{
    public class NodeCollection
    {
        private Dictionary<Hex, Node> collection;

        public NodeCollection()
        {
            collection = new Dictionary<Hex, Node>();
        }

        public bool Exist(Hex hex) => collection.ContainsKey(hex);
        public void Add(Node node) => collection.Add(node.hex, node);

        public void Add(List<Node> list)
        {
            foreach (Node node in list)
            {
                Add(node);
            }
        }
        public Node Get(Hex hex) => Exist(hex) ? collection[hex] : null;
        public List<Node> Get(List<Hex> hexes)
        {
            var result = new List<Node>();
            foreach (var hex in hexes)
            {
                if(Exist(hex))
                    result.Add(Get(hex));
            }
            return result;
        }
    }
}