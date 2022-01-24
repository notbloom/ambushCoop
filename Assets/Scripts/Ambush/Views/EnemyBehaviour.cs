using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Ambush
{
    public class EnemyBehaviour : MonoBehaviour, IAgentBehaviour
    {
        public SpriteRenderer spriteRenderer;
        private BoardEnemy _boardEnemy;
        public BoardEnemy boardEnemy
        {
            get
            {
                return _boardEnemy;
                
            }
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
        public Slider slider;
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

        public void ShowHP(float hp)
        {
            slider.value = hp;
        }

        // Use this for initialization
        void Start()
        {
            if (slider != null)
            {
                slider.maxValue = boardEnemy.baseMaxHealth;
                slider.value = boardEnemy.currentHealth;
            }
        }
        public float CurrentHp() => slider.value;
        // Update is called once per frame
        void Update()
        {

        }
    }

}