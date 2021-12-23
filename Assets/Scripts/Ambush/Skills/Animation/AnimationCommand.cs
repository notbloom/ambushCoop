using System.Collections;
using UnityEngine;

namespace Ambush{

   public abstract class AnimationCommand : ScriptableObject
   {
       public abstract IEnumerator Animate();
   }
}