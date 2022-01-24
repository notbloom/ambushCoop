using UnityEngine;
using System.Collections.Generic;
namespace Ambush
{
    //[CreateAssetMenu(fileName = "TurnAction", menuName = "Char/TurnAction", order = 0)]
    public class ActionFactory : ScriptableObject{

        public Sprite uiSprite;
        public int cost = 1;   
        
        public virtual IActionController Generate() {

            SimpleAttackController controller = new SimpleAttackController();
            controller.cost = cost;            
            return controller;
        }
    }
}