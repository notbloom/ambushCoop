using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResourcesIO
{
    static string persistent_url(string string_id)
    {
        return Application.persistentDataPath + Path.DirectorySeparatorChar + string_id + ".json";
    }
    public static string folderUrl(string folder)
    {
        return Application.persistentDataPath + Path.DirectorySeparatorChar + folder;
    }

    public static T LoadObjectDataByID<T>(string string_id)
    {
        T dataObject;
        if (File.Exists(persistent_url(string_id)))
        {
            string json = File.ReadAllText(persistent_url(string_id));
            dataObject = JsonUtility.FromJson<T>(json);
        }
        else
        {
            return default(T);
            //data = Resources.Load<SongInfo>("Avatar Data"); //????
        }
        return dataObject;
    }
    public static void SaveObjectByID(string string_id)
    {

    }
}
