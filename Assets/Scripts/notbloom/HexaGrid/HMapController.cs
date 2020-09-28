using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace notbloom.HexagonalMap
{
    public class HMapController
    {
        public HMap map;

        public void Init()
        {
            map = new HMap();

        }
        //public void 
        public void StepObjectTo(HObject _object, HNode toNode)
        {
            if (TryPlaceAt(toNode))
            {

                if (_object.node.triggers != null)
                {
                    foreach (HTrigger trigger in _object.node.triggers)
                    {
                        trigger.OnExit();
                    }
                }
                //TODO this may cause it to be in the air
                _object.node.occupant = null;

                _object.node = toNode;
                toNode.occupant = _object;
            }

        }
        public bool TryPlaceAt(HNode node)
        {
            if (node.occupant != null)
                return false;
            if (node.triggers != null)
            {
                foreach (HTrigger trigger in node.triggers)
                {
                    trigger.OnEnter();
                }
            }

            return true;
        }
        //map.CreateSimpleGrid(rows, cols);
    }
}