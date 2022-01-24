// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.IO;
// using notbloom.HexagonalMap;
// using UnityEngine;
// public class Spawner : MonoBehaviour
// {
//
//     //    [SerializeField]
//     //TODO SERIALIZABLE DICTIONARY
//     //public Dictionary<ObjectDataTypes, GameObject> spawnerDictionary;
//     public List<GameObject> prefabs;
//     public List<ObjectDataTypes> types;
//     private static Spawner instance;
//
//     private void Awake()
//     {
//         if (instance == null)
//         {
//             instance = this;
//         }
//     }
//     public static void Spawn(ObjectInstaceData objectInstaceData)
//     {
//         int index = instance.types.IndexOf(objectInstaceData.type);
//         GameObject spawn = Instantiate(instance.prefabs[index], Vector3.zero, Quaternion.identity);
//         ISpawn iSpawn = spawn.GetComponent<ISpawn>();
//         iSpawn.Spawn(objectInstaceData);
//     }
// }