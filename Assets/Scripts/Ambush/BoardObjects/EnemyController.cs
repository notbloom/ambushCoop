using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ambush { 
    public class EnemyController : MonoBehaviour
    {
        private BoardEnemy _boardEnemy;
        public BoardEnemy boardEnemy {
            get { return _boardEnemy; }
            set {
                _boardEnemy = value;
                Display();
            }
        }
        public int actionCount;

        public List<ScriptableCard> cards;
        public ScriptableCard currentCard => cards[actionCount];

        public void Display() {

        }
        public string Intent()
        {
            string intent = "";
            foreach (ScriptableCard card in cards)
            {
                intent += card.description + "\n";
            }
            return intent;
        }
        public void PlayTurn()
        {
            foreach (ScriptableCard card in cards)
            {
                // card.AITurn(boardEnemy.position, boardEnemy);
            }
            // TurnSystem.EndTurn(this);
        }

    }
}
