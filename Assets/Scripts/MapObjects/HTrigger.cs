using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
public class HTrigger : ScriptableObject
{
    public HNode node;
    public List<ScriptableAction> OnSpawnActions;
    public List<ScriptableAction> OnEnterActions;
    public List<ScriptableAction> OnStayActions;
    public List<ScriptableAction> OnExitActions;
    public List<ScriptableAction> OnDestroyActions;
    public void OnSpawn()
    {
        foreach (ScriptableAction action in OnSpawnActions)
        {
            action.PerformAction(node, null);
        }
    }
    public void OnEnter()
    {
        foreach (ScriptableAction action in OnEnterActions)
        {
            action.PerformAction(node, null);
        }
    }
    public void OnStay()
    {
        foreach (ScriptableAction action in OnStayActions)
        {
            action.PerformAction(node, null);
        }
    }
    public void OnExit()
    {
        foreach (ScriptableAction action in OnExitActions)
        {
            action.PerformAction(node, null);
        }
    }
    public void OnDestroy()
    {
        foreach (ScriptableAction action in OnDestroyActions)
        {
            action.PerformAction(node, null);
        }
    }
}