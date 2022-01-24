using UnityEngine;

namespace Ambush
{
    public class EnemyController : MonoBehaviour
    {
        private BoardEnemy _boardEnemy;
        public int actionCount;

        public BoardEnemy boardEnemy
        {
            get => _boardEnemy;
            set
            {
                _boardEnemy = value;
                Display();
            }
        }

        //public List<ScriptableCard> cards;
        //public ScriptableCard currentCard => cards[actionCount];

        public void Display()
        {
        }

        public string Intent()
        {
            var intent = "";
            // foreach (ScriptableCard card in cards)
            // {
            //     intent += card.description + "\n";
            // }
            return intent;
        }

        public void PlayTurn()
        {
            // foreach (ScriptableCard card in cards)
            // {
            //     // card.AITurn(boardEnemy.position, boardEnemy);
            // }
            // TurnSystem.EndTurn(this);
        }
    }
}