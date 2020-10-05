using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyAgent))]
public class EnemyAgentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EnemyAgent enemyAgent = (EnemyAgent)target;
        enemyAgent.ShowSprite();
    }
}
