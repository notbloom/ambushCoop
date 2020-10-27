using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "BaseStats", menuName = "Char/BaseStats", order = 0)]
public class BaseStats : ScriptableObject//, ISerializable
{
    public string id;
    public int move;
    public int attack;
    public int range;
    public int targets;
    public int health;
    public int armor;

    // public void GetObjectData(SerializationInfo info, StreamingContext context)
    // {        
    //     info.AddValue("id", id, typeof(string));          
    // }    
    // public BaseStats(SerializationInfo info, StreamingContext context)
    // {        
    //     id = (string) info.GetValue("id", typeof(string));
    //     BaseStats b = ResourcesIO.LoadResource<BaseStats>(id);
    //     move = b.move;
    //     attack = b.attack;
    //     range = b.range;
    //     targets = b.targets;
    //     health = b.health;
    //     armor = b.armor;
    // }

}
