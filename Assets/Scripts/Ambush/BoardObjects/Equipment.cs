using System.Collections.Generic;
using UnityEngine;
namespace Ambush
{
    [SerializeField]
    public class Equipment : ScriptableObject
    {

        public string readableName;

        public List<Stat> stats;
        //public void Equip(BoardAgent boardAgent)
        //{
        //    boardAgent.maxHealth += 10;
        //}
        //public void Unequip(BoardAgent boardAgent)
        //{
        //    boardAgent.maxHealth -= 10;
        //}
    }
}