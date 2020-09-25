using UnityEngine;

[CreateAssetMenu(fileName = "RoundModifier", menuName = "Char/RoundModifier", order = 0)]
public class RoundModifier : ScriptableObject
{
    //Set is true when override, false when Add
    public bool setMove;
    public int move;
    public bool setAttack;
    public int attack;
    public bool setArmor;
    public int armor;
    public bool setTargets;
    public int targets;

}
