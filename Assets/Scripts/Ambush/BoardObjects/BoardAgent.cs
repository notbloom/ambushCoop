using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using notbloom.HexagonalMap;
namespace Ambush
{
    
    public enum StatModifierType {
        maxHealthModifier, movementModifier, physicalDamageModifier, magicalDamageModifier
    }
    public class StatModifier {
        public StatModifierType type;
        public ushort value;
    }
    public enum StatType
    {
        movement, step, physicalDamage, magicalDamage, pierce, armor, maxHp, currentHp
    }

    public class Stat
    {
        public StatType type;
        public int value;
    }

    public enum SpecialAbilityTrigger { OnTurnStart, OnTurnEnd, OnDamagePlayer, OnDamageEnemy, OnKillEnemy, }
    public class SpecialAbility
    {

    }
    public class Equipment
    {
        public string name;
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
    public class BoardAgent : BoardObject
    {
     //   public Node position;
       // public BoardAgentStats baseStats;
       // public Sprite boardSprite;
        public string unique_id;
        public string id; //name        
        public List<Equipment> equipment;

        // Stats
        //initial_fixed_stats        
        public ushort initiative;
        public string readableName;

        // Base Stats
        public int baseMovement; // amount of steps per turn         
        public int baseMaxHealth;
        public int basePhysicalDamage; // adds physical damage
        public int baseMagicalDamage; // adds magical damage        

        //Usable Stats
        public int movement; // amount of steps per turn         
        public int maxHealth;
        public int physicalDamage; // adds physical damage
        public int magicalDamage; // adds magical damage
        public int currentHealth;

        public string Description() { return $"HP:{baseMaxHealth}"; }

        public int GetMaxHealth() => maxHealth + GetStatModifier(StatType.maxHp);
        public int GetMovement() => movement + GetStatModifier(StatType.movement);
        public int GetMagicalDamage() => magicalDamage + GetStatModifier(StatType.magicalDamage);
        public int GetPhysicalDamage() => physicalDamage + GetStatModifier(StatType.physicalDamage);

        public int GetPhysicalDamage2()
        {
            int r = physicalDamage;

            var o = from e in equipment
                    from s in e.stats
                    where s.type == StatType.physicalDamage
                    select s.value;


            foreach (Equipment e in equipment)
            {
                // e.stats.Where(s => s.type == StatType.physicalDamage).

                foreach (Stat a in e.stats)
                {
                    if (a.type == StatType.physicalDamage)
                    {
                        r += a.value;
                    }
                }
            }

            return r;
        }

        public int GetStatModifier(StatType statType)
        {
            int r = 0;

            var o = from e in equipment
                    from s in e.stats
                    where s.type == statType
                    select s.value;

            foreach (int i in o)
            {
                r += i;
            }
            return r;


        }

    }
    public class BoardEnemy : BoardAgent
    {

    }
}