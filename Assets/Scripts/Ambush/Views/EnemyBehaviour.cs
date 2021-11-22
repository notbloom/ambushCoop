using UnityEngine;
using System.Collections;

namespace Ambush
{
    public class EnemyBehaviour : MonoBehaviour, IAgentBehaviour
    {
        public SpriteRenderer spriteRenderer;        
        public BoardEnemy boardEnemy;

        public Transform Transform() => transform;
        public void PlayTurn(){
            // foreach (ScriptableCard card in cards)
            // {
            //     card.AITurn(boardEnemy.position, this);
            // }
            // TurnSystem.EndTurn(this);
        }
        public void ShowIntent()
        {

        }
        public void HideIntent()
        {

        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}