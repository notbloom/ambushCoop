namespace Ambush
{

    public class MoveAction : IAction
    {

        readonly BoardAgent boardAgent;
        readonly Node target;
        readonly MoveAnimationFactory animationFactory;

        public MoveAction( BoardAgent boardAgent,  Node target, MoveAnimationFactory animationFactory)
        {
            this.boardAgent = boardAgent;
            this.target = target;
            this.animationFactory = animationFactory;
        }

        public void Do()
        {

            var anim = animationFactory.Generate(boardAgent, target);
            AnimationInvoker.Enqueue(anim);
            //
            // if (target.occupant == null) return;
            // if (!(target.occupant is BoardAgent)) return;
            //
            // BoardAgent targetAgent = target.occupant as BoardAgent;
            // targetAgent.currentHealth -= damage;
            // ReceiveDamageAnimationCommand receiveDamage =
            //     new ReceiveDamageAnimationCommand(targetAgent.view, targetAgent.currentHealth, 0.2f);
            // AnimationInvoker.Enqueue(receiveDamage);
            //TODO Create a better way for this, also add impact animation and lower hp animation
        }
    }
}
