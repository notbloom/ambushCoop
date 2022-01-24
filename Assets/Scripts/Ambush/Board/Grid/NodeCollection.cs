using System.Collections.Generic;

namespace Ambush
{
    public class NodeCollection
    {
        private readonly Dictionary<Hex, Node> collection;

        public NodeCollection()
        {
            collection = new Dictionary<Hex, Node>();
        }

        public bool Exist(Hex hex)
        {
            return collection.ContainsKey(hex);
        }

        public void Add(Node node)
        {
            collection.Add(node.hex, node);
        }

        public void Add(List<Node> list)
        {
            foreach (var node in list) Add(node);
        }

        public Node Get(Hex hex)
        {
            return Exist(hex) ? collection[hex] : null;
        }

        public List<Node> Get(List<Hex> hexes)
        {
            var result = new List<Node>();
            foreach (var hex in hexes)
                if (Exist(hex))
                    result.Add(Get(hex));
            return result;
        }
    }
}