using UnityEngine;
using UnityEngine.UI;

namespace Ambush
{
    public class EnemyBehaviour : MonoBehaviour, IAgentBehaviour
    {
        private BoardEnemy _boardEnemy;
        public Slider slider;
        public SpriteRenderer spriteRenderer;

        public BoardEnemy boardEnemy
        {
            get => _boardEnemy;
            set
            {
                _boardEnemy = value;
                if (slider != null)
                {
                    slider.maxValue = boardEnemy.baseMaxHealth;
                    slider.value = boardEnemy.baseMaxHealth;
                }
            }
        }

        public Transform Transform()
        {
            return transform;
        }

        public void PlayTurn()
        {
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

        public void ShowHP(float hp)
        {
            slider.value = hp;
        }

        public float CurrentHp()
        {
            return slider.value;
        }

        // Use this for initialization
        private void Start()
        {
            if (slider != null)
            {
                slider.maxValue = boardEnemy.baseMaxHealth;
                slider.value = boardEnemy.currentHealth;
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}