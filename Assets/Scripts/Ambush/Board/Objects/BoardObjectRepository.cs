using System.Collections.Generic;
using UnityEngine;

namespace Ambush
{
    public class BoardObjectRepository : MonoBehaviour
    {
        public Dictionary<string, ScriptableEnemy> GetScriptableEnemy;

        public Dictionary<string, ScriptablePlayerClass> GetScriptablePlayerClasses;

        // Use this for initialization
        public ScriptableEnemy[] scriptableEnemies;

        public ScriptablePlayerClass[] scriptablePlayerClasses;


        private void Awake()
        {
            GetScriptableEnemy = new Dictionary<string, ScriptableEnemy>();
            for (var i = 0; i < scriptableEnemies.Length; i++)
                GetScriptableEnemy.Add(scriptableEnemies[i].name, scriptableEnemies[i]);

            GetScriptablePlayerClasses = new Dictionary<string, ScriptablePlayerClass>();
            for (var i = 0; i < scriptablePlayerClasses.Length; i++)
                GetScriptablePlayerClasses.Add(scriptablePlayerClasses[i].name, scriptablePlayerClasses[i]);
        }

        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}