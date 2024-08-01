using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    [SerializeField] string stateName;

    [SerializeField] protected float speedInAir = 5f;
    [SerializeField, Range(0f, 1f)] protected float transitionDurationTime = 0.1f;

    int stateHash;
    protected Animator animator;
    protected PlayerStateMachine playerStateMachine;

    protected PlayerInput playerInput;

    protected PlayerController playerController;

    protected float currentSpeed;

    protected float stateStartTime;
    protected float StartDuration => Time.time - stateStartTime;
    protected bool IsAnimationFinished => StartDuration >= animator.GetCurrentAnimatorStateInfo(0).length;

    void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }

    public void Initialize(Animator animator, PlayerInput playerInput, PlayerController playerController, PlayerStateMachine playerStateMachine)
    {
        this.animator = animator;
        this.playerStateMachine = playerStateMachine;
        this.playerController = playerController;
        this.playerInput = playerInput;
    }
    public virtual void OnEnter()
    {
        animator.CrossFade(stateHash, transitionDurationTime);
        stateStartTime = Time.time;
    }

    public virtual void OnExit()
    {

    }
    public virtual void OnUpdate()
    {

    }

    public virtual void OnFixedUpdate()
    {
        
    }
}
