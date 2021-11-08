using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ambush {
    [CreateAssetMenu(fileName = "new ScriptableEnemy", menuName = "Data / Enemy", order = 0)]
    public class ScriptableEnemy : ScriptableObject
    {
        public Sprite boardSprite;
        //stats

        public List<Equipment> equipment;

        // Stats
        //initial_fixed_stats        
        public ushort initiative;
        public string readableName;        
        // Base Stats
        public int baseMovement; // amount of steps per turn         
        public int baseMaxHealth;
        public int basePhysicalDamage; // adds physical damage
        public int baseMagicalDamage;
        //etc

        public BoardEnemy Create() {
            BoardEnemy newEnemy = new BoardEnemy();

            newEnemy.boardSprite = boardSprite;
            newEnemy.initiative = initiative;
            newEnemy.readableName = readableName;

            newEnemy.baseMovement = baseMovement;
            newEnemy.baseMaxHealth = baseMaxHealth;
            newEnemy.basePhysicalDamage = basePhysicalDamage;
            newEnemy.baseMagicalDamage = baseMagicalDamage;

            return newEnemy;
        }
    }
}
//public static class ScriptableEnemySerializer
//{
//    public static void WriteArmor(this NetworkWriter writer, Armor armor)
//    {
//        // no need to serialize the data, just the name of the armor
//        writer.WriteString(armor.name);
//    }
//    public static Armor ReadArmor(this NetworkReader reader)
//    {
//        // load the same armor by name.  The data will come from the asset in Resources folder
//        return Resources.Load(reader.ReadString());
//    }
//}
