using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ambush{  
    public class BoardObjectRepository : MonoBehaviour
    {
        // Use this for initialization
        public ScriptableEnemy[] scriptableEnemies;
        public Dictionary<string, ScriptableEnemy> GetScriptableEnemy;

        private void Awake()
        {
            GetScriptableEnemy = new Dictionary<string, ScriptableEnemy>();
            for (int i = 0; i < scriptableEnemies.Length; i++)
            {
                GetScriptableEnemy.Add(scriptableEnemies[i].name, scriptableEnemies[i]);
            }
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}