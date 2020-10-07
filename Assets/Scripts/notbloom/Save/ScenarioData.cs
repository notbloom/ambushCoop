using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using notbloom.HexagonalMap;
using UnityEngine;

[Serializable]
public class MObject
{
    string id;
}
public class ScenarioData
{
    public List<NodeData> s_nodes;
    public List<ObjectInstaceData> s_objects;

    public string string_id;

    static string url(string scenario_id)
    {
        return Application.persistentDataPath + Path.DirectorySeparatorChar + scenario_id + ".json";

    }
    public static string folderUrl(string folder)
    {
        return Application.persistentDataPath + Path.DirectorySeparatorChar + folder;
    }
    public static void Save(ScenarioData scenarioData)
    {
        string json = JsonUtility.ToJson(scenarioData);
        Directory.CreateDirectory(folderUrl("Scenarios"));
        Debug.Log(folderUrl("Scenarios"));
        File.WriteAllText(url(scenarioData.string_id), json);
    }
}