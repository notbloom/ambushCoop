using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ambush
{
    // en Board solo implementar la data, dejarle la funcionalidad a GameEngine
    public class Board : MonoBehaviour
    {
        //no serializar este
        public BoardObjectRepository repository;

        public Map map;
        public List<BoardPlayer> boardPlayers;
        public List<PlayerBehaviour> playerBehaviours;
        public List<BoardEnemy> boardEnemies;
        public BoardPlayer Player(string id) { return null; }
        
        public void Agents() { }
        public void Object() { }
        public void Turn() { }

        public static Board Load(string ID) { return null; }


        public void CreateGeneric() {
            map.CreateGeneric();
            SpawnGenericEnemies();
            playerBehaviours = new List<PlayerBehaviour>();
            SpawnPlayer();
        }


        public void SpawnPlayer() {
            GameObject go = Instantiate(Resources.Load("Player/default", typeof(GameObject))) as GameObject;
            BoardPlayer boardPlayer = repository.GetScriptablePlayerClasses["adventurer"].Create();
            PlayerBehaviour playerBehaviour = go.GetComponent<PlayerBehaviour>();
            boardPlayer.view = playerBehaviour;
            playerBehaviour.boardAgent = boardPlayer;
            playerBehaviours.Add(playerBehaviour);
            PlaceAgent(boardPlayer, map.FindNodeByVector2Int(new Vector2Int(1, 1)));
        }


        public void SpawnGenericEnemies() {
            for (int i = 0; i < 5; i++)
            {
                // Create Enemy from ScriptableObject EnemyData
                GameObject go = Instantiate(Resources.Load("Enemies/default", typeof(GameObject))) as GameObject;

                //COMO CREAR LOS ENEMIGOS?
                /* DESDE LA DATA, CREAR UN VIEW Y REGISTRARLO
                 * DE QUIEN ES LA RESPONSABILIDAD DE BINDEAR?
                 * DE LA BOARD?
                 * BOARD CREATE UN WN
                 */

                //TODO hacer la call mas amigable?
                BoardEnemy boardEnemy = repository.GetScriptableEnemy["default"].Create();

                boardEnemy.view = go.GetComponent<EnemyBehaviour>();                
                PlaceAgent(boardEnemy, map.FindNodeByVector2Int(new Vector2Int(i, 5)));
            }
        }
        public bool PlaceAgent(BoardAgent agent, Node node) {
            if (node.occupant != null) return false;
            node.occupant = agent;
            agent.position = node;
            agent.view.Transform().position = node.ToVector3();

            return true;
        }
        public void SpawnEnemy(ScriptableEnemy ScriptableEnemy, Vector2Int position) {
            GameObject go = Instantiate(Resources.Load("Enemies/default", typeof(GameObject))) as GameObject;
            go.GetComponent<EnemyController>();
            
        }
    }
}