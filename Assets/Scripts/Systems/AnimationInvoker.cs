using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
public class AnimationInvoker : MonoBehaviour
{
    static AnimationInvoker instance;
    public Transform target;
    Queue<ScriptableNodeAnimation> animationCommands;

    private bool busy = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        animationCommands = new Queue<ScriptableNodeAnimation>();
        //Step();
    }

    void Update()
    {
        if (busy)
            return;
        if (animationCommands.Count > 0)
            Step();
    }
    public static void Enqueue(ScriptableNodeAnimation animationCommand)
    {
        instance.animationCommands.Enqueue(animationCommand);
    }
    public void Step()
    {
        busy = true;
        StartCoroutine(StartStep(callBack =>
        {
            // callBack is going to be null until it’s set
            if (callBack != null)
            {
                busy = false;
                // Now callBack acts as an int
                // Debug.Log(callBack);
            }
        }));
    }

    public IEnumerator StartStep(System.Action<string> callBack)
    {
        //MoveAnimation m = new MoveAnimation(target, Vector3.zero, 100f);

        // Waits 3 seconds
        yield return animationCommands.Dequeue().Animate(); // m.Animate();

        // Set callBack to 1 after 3 seconds
        callBack("animator");
    }
}

// public abstract class ScriptableAnimation : ScriptableObject
// {
//     public abstract IEnumerator Animate();
// }


public class DamageAnimation : ScriptableNodeAnimation
{
    public float animationTime;
    public Agent agent;
    public HDamageInstance damageInstance;
    public float startTime;

    public float startingHp;

    public DamageAnimation(Agent agent, HNode from, List<HNode> to, HDamageInstance damageInstance, float animationTime) : base(from, to)
    {

        this.agent = agent;
        this.damageInstance = damageInstance;
        this.animationTime = animationTime;
    }
    public override IEnumerator Animate()
    {
        startingHp = agent.hp;
        startTime = Time.time;
        yield return _Animate();
    }
    private IEnumerator _Animate()
    {
        while (Time.time < startTime + animationTime)
        {
            agent.hp = Mathf.Lerp(startingHp, startingHp - damageInstance.amount, (Time.time - startTime) / animationTime);
            agent.UpdateView();
            yield return null;
        }
        //TODO change this math to agent damage processing
        agent.hp = startingHp - damageInstance.amount;
        agent.UpdateView();
    }

}