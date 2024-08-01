using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land", fileName = "PlayerStateLand")]
public class PlayerStateLand : PlayerState
{
    [SerializeField] float stiffenTime = 0.2f;
    public override void OnEnter()
    {
        base.OnEnter();
        playerController.SetVelocity(Vector3.zero);
        //playerController.CanAirJump = true;
    }
    public override void OnUpdate()
    {
        if (playerInput.IsJump)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateJumpUp));
        }

        if (StartDuration < stiffenTime)
        {
            return;
        }

        if (playerInput.StartMove)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateRun));
        }

        if (IsAnimationFinished)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateIdle));
        }
    }
}
