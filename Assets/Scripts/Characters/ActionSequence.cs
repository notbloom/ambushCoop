using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ActionSequence", menuName = "Char/ActionSequence", order = 0)]
public class ActionSequence : ScriptableObject
{
    public List<TurnAction> actions;
}
