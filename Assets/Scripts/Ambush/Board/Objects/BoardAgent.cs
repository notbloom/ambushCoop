using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace Ambush
{
    public class BoardAgent : BoardObject
    {
        public int baseMagicalDamage; // adds magical damage        
        public int baseMaxHealth;

        // Base Stats
        public int baseMovement; // amount of steps per turn         
        public int basePhysicalDamage; // adds physical damage
        public int currentHealth;
        [SerializeField]
        public List<Equipment> equipment;
        public string id; //name        

        // Stats
        //initial_fixed_stats        
        public ushort initiative;
        public int magicalDamage; // adds magical damage
        public int maxHealth;

        //Usable Stats
        public int movement; // amount of steps per turn         
        public int physicalDamage; // adds physical damage

        public string readableName;

        //   public Node position;
        // public BoardAgentStats baseStats;
        // public Sprite boardSprite;
        public string unique_id;
        public int previewHealth;

        public virtual void PlayTurn() { }

        public string Description()
        {
            return $"HP:{currentHealth}";
        }


        public int GetMaxHealth()
        {
            return baseMaxHealth + GetStatModifier(StatType.MaxHp);
        }

        public int GetMovement()
        {
            return movement + GetStatModifier(StatType.Movement);
        }

        public int GetMagicalDamage()
        {
            return magicalDamage + GetStatModifier(StatType.MagicalDamage);
        }

        public int GetPhysicalDamage()
        {
            return physicalDamage + GetStatModifier(StatType.PhysicalDamage);
        }

        public int GetStatModifier(StatType statType)
        {
            return 0;
            // var statTypeValueSum = equipment
            //     .SelectMany(e => e.stats)
            //     .Where(s => s.type == statType)
            //     .Select(s => s.value)
            //     .Sum();
            // return statTypeValueSum;
        }
    }
}