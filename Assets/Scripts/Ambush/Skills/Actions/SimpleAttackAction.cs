namespace Ambush
{
    public class SimpleAttackAction : IAction
    {
        private readonly ThrowableAnimationFactory animationFactory;
        private readonly int damage;
        private readonly Node origin;
        private readonly Node target;

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

            var targetAgent = target.occupant as BoardAgent;
            targetAgent.currentHealth -= damage;
            var receiveDamage =
                new ReceiveDamageAnimationCommand(targetAgent.view, targetAgent.currentHealth, 0.2f);
            AnimationInvoker.Enqueue(receiveDamage);
            //TODO Create a better way for this, also add impact animation and lower hp animation
        }
    }
}