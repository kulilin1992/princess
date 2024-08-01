using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/CoyoteTime", fileName = "PlayerStateCoyoteTime")]
public class PlayerStateCoyoteTime : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float coyoteTime = 0.1f;
    public override void OnEnter()
    {
        base.OnEnter();
        //animator.Play("Run");
        playerController.SetUseGravity(false);
    }

    public override void OnExit()
    {
        //base.OnExit();
        playerController.SetUseGravity(true);
    }

    public override void OnUpdate()
    {


        if (playerInput.IsJump)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateJumpUp));
        }

        if (StartDuration > coyoteTime || !playerInput.StartMove)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateFall));
        }

    }

    public override void OnFixedUpdate()
    {
        //base.OnFixedUpdate();
        //playerController.SetVelocityX(runSpeed);
        playerController.Move(runSpeed);
    }
}
