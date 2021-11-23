using UnityEngine;
using System.Collections.Generic;
namespace Ambush
{	
    public interface IActionController{
		int Cost();
		void OnSkillHover(PlayerBehaviour playerBehaviour);
		void OnSkillExitHover(PlayerBehaviour playerBehaviour);
		void OnSkillActivate(PlayerBehaviour playerBehaviour);
		void OnSkillCancel(PlayerBehaviour playerBehaviour);
		void OnNodeEnter(PlayerBehaviour playerBehaviour, Node node);
		void OnNodeExit(PlayerBehaviour playerBehaviour, Node node);
		void OnNodePress(PlayerBehaviour playerBehaviour, Node node);

    }
}