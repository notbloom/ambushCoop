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
    public class HObject //: ScriptableObject
    {
        public HObjectFactions faction;
        // public HObjectTypes type;
        public HNode node;
        //public new string name;
        public Agent agent;
        //void SetAtNode(HNode node);
        //  bool OnTrigger(Agent agentWhoTriggered);
    }
    // public class HScriptableObjectType : ScriptableObject
    // {
    //     public HObjectFactions faction;
    //     public HObjectTypes type;

    // }
    public class HDamageInstance
    {
        public float amount;
        //TODO add pierce and status here
        public HDamageInstance(float damage)
        {
            amount = damage;
        }
    }
    public interface HICanReceiveDamage
    {
        void ReceiveDamage(HDamageInstance damageInstance);
    }

}