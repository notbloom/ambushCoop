﻿using System.Collections.Generic;
using UnityEngine;

namespace Ambush
{
    [SerializeField]
    [CreateAssetMenu(fileName = "new Equipment", menuName = "Equipment", order = 0)]
    public class Equipment : ScriptableObject
    {
        public List<ActionFactory> actionFactories;
        public string readableName;
        public List<Stat> stats;
        public Sprite uiSprite;

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