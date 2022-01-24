using UnityEngine;

namespace Ambush
{
    //[CreateAssetMenu(fileName = "TurnAction", menuName = "Char/TurnAction", order = 0)]
    public abstract class ScriptableAction : ScriptableObject, IActionController
    {
        //   public abstract void OnSkillHover();
        //public abstract void OnSkillExitHover();
        //public abstract void OnSkillActivate();
        //public abstract void OnSkillCancel();
        //public abstract void OnNodeEnter(Node node);
        //public abstract void OnNodeExit(Node node);
        //public abstract void OnNodePress(Node node);
        public abstract int Cost();
        public abstract Sprite UISprite();
        public abstract void OnSkillHover(PlayerBehaviour playerBehaviour);
        public abstract void OnSkillExitHover(PlayerBehaviour playerBehaviour);
        public abstract void OnSkillActivate(PlayerBehaviour playerBehaviour);
        public abstract void OnSkillCancel(PlayerBehaviour playerBehaviour);
        public abstract void OnNodeEnter(PlayerBehaviour playerBehaviour, Node node);
        public abstract void OnNodeExit(PlayerBehaviour playerBehaviour, Node node);
        public abstract void OnNodePress(PlayerBehaviour playerBehaviour, Node node);
    }
}