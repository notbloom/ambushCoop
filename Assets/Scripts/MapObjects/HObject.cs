using UnityEngine;
namespace notbloom.HexagonalMap
{
    public enum HObjectFactions
    {
        HPlayerFaction, HEnemyFaction, HNeutralFaction, HAnyFaction
    }
    public enum HObjectTypes
    {
        HObject, HTrigger
    }
    // public interface  HObject
    // {
    //     HObjectFactions Faction();
    //     HObjectTypes Type();
    //     HNode Node();
    //     void SetAtNode(HNode node);
    //     //  bool OnTrigger(Agent agentWhoTriggered);
    // }
    public abstract class HObject : ScriptableObject
    {
        public HObjectFactions faction;
        public HObjectTypes type;
        public HNode node;
        public new string name;
        public Agent agent;
        //void SetAtNode(HNode node);
        //  bool OnTrigger(Agent agentWhoTriggered);
    }
    public interface HICanReceiveDamage
    {
        void ReceiveDamage();
    }

}