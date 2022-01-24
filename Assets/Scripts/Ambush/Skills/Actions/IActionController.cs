using UnityEngine;
using System.Collections.Generic;
namespace Ambush
{	
    public interface IActionController{
		int Cost();

		Sprite UISprite();
		//En la barra
		void OnSkillHover(PlayerBehaviour playerBehaviour);
		void OnSkillExitHover(PlayerBehaviour playerBehaviour);

		//apretarla de la barra
		void OnSkillActivate(PlayerBehaviour playerBehaviour);

		//arrepentio
		void OnSkillCancel(PlayerBehaviour playerBehaviour);
        
        //que es lo que va a pasar en el nodo en el tablero
		void OnNodeEnter(PlayerBehaviour playerBehaviour, Node node);
		void OnNodeExit(PlayerBehaviour playerBehaviour, Node node);

		//Queremos que lo ejecute y su animacion;
		void OnNodePress(PlayerBehaviour playerBehaviour, Node node);
    }
}