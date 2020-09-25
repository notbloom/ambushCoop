using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Char/Enemy", order = 0)]
public class Enemy : ScriptableObject
{
    public BaseStats baseStats;
    public List<Status> resistances;
    public List<ActionSequence> turnActions;
}