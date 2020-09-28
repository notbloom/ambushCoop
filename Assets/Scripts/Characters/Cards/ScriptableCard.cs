using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableCard : ScriptableObject
{
    List<ScriptableAction> actions;

    public void Play()
    {
        foreach (ScriptableAction action in actions)
        {

        }
    }
}
