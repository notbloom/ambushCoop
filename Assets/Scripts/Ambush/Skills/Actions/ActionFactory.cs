using UnityEngine;

namespace Ambush
{
    //[CreateAssetMenu(fileName = "TurnAction", menuName = "Char/TurnAction", order = 0)]
    public class ActionFactory : ScriptableObject
    {
        public int cost = 1;

        public Sprite uiSprite;

        public virtual IActionController Generate()
        {
            var controller = new SimpleAttackController();
            controller.cost = cost;
            return controller;
        }
    }
}