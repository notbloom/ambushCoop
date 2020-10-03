using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
[CreateAssetMenu(fileName = "new InitiativeTurnAnimationFactory", menuName = "Animation/UI/InitiativeTurnAnimationFactory", order = 0)]

// public class InitiativeTurnAnimationFactory 
// {

//     public AnimationCommand Generate(GameObject caster, List<HNode> from, List<HNode> to, float animationTime)
//     {
//         SpawnAtTargetAnimationCommand animationCommand = new SpawnAtTargetAnimationCommand(caster.GetComponent<AgentBase>().agent, from[0], to, this.animationTime);

//         return animationCommand;
//     }
// }
public class InitiativeTurnAnimationCommand : AnimationCommand
{
    public InitiativeView iView;
    private bool on;
    public float animationTime;
    public float startTime;

    List<HNode> to;

    public InitiativeTurnAnimationCommand(InitiativeView iView, bool on, float animationTime)
    {
        this.iView = iView;
        this.on = on;
        this.animationTime = animationTime;
    }
    public override IEnumerator Animate()
    {
        startTime = Time.time;
        yield return _Animate();
    }
    private IEnumerator _Animate()
    {
        while (Time.time < startTime + animationTime)
        {
            if (on)
            {
                iView.panelImageUI.color = Color.Lerp(iView.agentBase.visibleCharacter.initiativeColorOffTurn,
                iView.agentBase.visibleCharacter.initiativeColorOnTurn, (Time.time - startTime) / animationTime);
            }
            else
            {
                iView.panelImageUI.color = Color.Lerp(iView.agentBase.visibleCharacter.initiativeColorOnTurn,
                iView.agentBase.visibleCharacter.initiativeColorOffTurn, (Time.time - startTime) / animationTime);
            }
            yield return null;
        }
        iView.panelImageUI.color = on ? iView.agentBase.visibleCharacter.initiativeColorOnTurn :
                iView.agentBase.visibleCharacter.initiativeColorOffTurn;
    }

}