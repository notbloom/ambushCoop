using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BaseStats", menuName = "Char/BaseStats", order = 0)]
public class BaseStats : ScriptableObject
{
    public int move;
    public int attack;
    public int range;
    public int targets;
    public int health;
    public int armor;

}
