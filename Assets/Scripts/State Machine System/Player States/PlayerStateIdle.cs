
using UnityEngine;


[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerStateIdle")]
public class PlayerStateIdle : PlayerState
{
    [SerializeField] float deceleration = 20f;
    public override void OnEnter()
    {
        base.OnEnter();
        //animator.Play("Idle");
        //playerController.SetVelocityX(0f);
        currentSpeed = playerController.MoveSpeed;
    }

    public override void OnUpdate()
    {
        // if (Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed)
        // {
        //     playerStateMachine.ChangeState(typeof(PlayerStateRun));

        // }
        if (playerInput.StartMove)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateRun));
        }

        if (playerInput.IsJump)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateJumpUp));
        }

        if (!playerController.IsGrounded)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateFall));
        }
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
    }

    public override void OnFixedUpdate()
    {
        playerController.SetVelocityX(currentSpeed * playerController.transform.localScale.x);
    }
}
