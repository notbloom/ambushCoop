namespace Ambush
{
 
    public class SimpleAttackAction : IAction
    {
        readonly int damage;
        readonly Node origin;
        readonly Node target;
        readonly ThrowableAnimationFactory animationFactory;

        public SimpleAttackAction(int damage, Node origin, Node target, ThrowableAnimationFactory animationFactory)
        {
            this.damage = damage;
            this.origin = origin;
            this.target = target;
            this.animationFactory = animationFactory;
        }

        public void Do()
        {
                var anim = animationFactory.Generate(origin, target);
                AnimationInvoker.Enqueue(anim);
                
                if (target.occupant == null) return;
                if (!(target.occupant is BoardAgent)) return;
                
                BoardAgent targetAgent = target.occupant as BoardAgent;
                targetAgent.currentHealth -= damage;
                ReceiveDamageAnimationCommand receiveDamage =
                    new ReceiveDamageAnimationCommand(targetAgent.view, targetAgent.currentHealth, 0.2f);
                AnimationInvoker.Enqueue(receiveDamage);
                //TODO Create a better way for this, also add impact animation and lower hp animation
        }
    }
}