using UnityEngine;
using System.Collections.Generic;
namespace Ambush
{
    //[CreateAssetMenu(fileName = "TurnAction", menuName = "Char/TurnAction", order = 0)]
    public class ActionFactory : ScriptableObject{

        public Sprite uiSprite;
        public int cost = 1;   
        
        public virtual IActionController Generate() {

            SimpleAttackAction action = new SimpleAttackAction();
            action.cost = cost;            
            return action;
        }
    }
}