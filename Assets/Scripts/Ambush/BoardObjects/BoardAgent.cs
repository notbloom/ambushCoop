using System.Collections.Generic;
using System.Linq;

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

        public string Description()
        {
            return $"HP:{baseMaxHealth}";
        }

        public int GetMaxHealth()
        {
            return maxHealth + GetStatModifier(StatType.MaxHp);
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

        public int GetPhysicalDamage2()
        {
            var r = physicalDamage;

            var o = from e in equipment
                from s in e.stats
                where s.type == StatType.PhysicalDamage
                select s.value;


            foreach (var e in equipment)
                // e.stats.Where(s => s.type == StatType.physicalDamage).

            foreach (var a in e.stats)
                if (a.type == StatType.PhysicalDamage)
                    r += a.value;

            return r;
        }

        public int GetStatModifier(StatType statType)
        {
            var r = 0;

            var o = from e in equipment
                from s in e.stats
                where s.type == statType
                select s.value;

            foreach (var i in o) r += i;
            return r;
        }
    }

    public class BoardEnemy : BoardAgent
    {
    }
}