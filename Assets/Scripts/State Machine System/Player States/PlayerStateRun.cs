
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "PlayerStateRun")]
public class PlayerStateRun : PlayerState
{

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceleration = 5f;
    public override void OnEnter()
    {
        base.OnEnter();
        //animator.Play("Run");
        currentSpeed = playerController.MoveSpeed;
    }

    public override void OnUpdate()
    {
        // if (!(Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed))
        // {
        //     playerStateMachine.ChangeState(typeof(PlayerStateIdle));
        // }

        if (!playerInput.StartMove)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateIdle));
        }

        if (playerInput.IsJump)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateJumpUp));
        }

        if (!playerController.IsGrounded)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateFall));
            //playerStateMachine.ChangeState(typeof(PlayerStateCoyoteTime));
        }
        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed,acceleration * Time.deltaTime);
    }

    public override void OnFixedUpdate()
    {
        //base.OnFixedUpdate();
        //playerController.SetVelocityX(runSpeed);
        playerController.Move(currentSpeed);
    }
}
