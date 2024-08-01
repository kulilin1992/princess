using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "PlayerStateFall")]
public class PlayerStateFall : PlayerState
{

    [SerializeField] AnimationCurve speedCurve;


    public override void OnUpdate()
    {
        if (playerController.IsGrounded)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateLand));
        }

        if (playerInput.IsJump)
        {
            if (playerController.CanAirJump)
            {
                playerStateMachine.ChangeState(typeof(PlayerStateAirJump));
            }
        }
    }

    public override void OnFixedUpdate()
    {
        playerController.Move(speedInAir);
        playerController.SetVelocityY(speedCurve.Evaluate(StartDuration));
    }
}
