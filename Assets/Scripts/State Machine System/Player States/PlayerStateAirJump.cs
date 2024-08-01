using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/AirJupm", fileName = "PlayerStateAirJump")]
public class PlayerStateAirJump : PlayerState
{
    [SerializeField] float jumpForce = 10f;
    [SerializeField] ParticleSystem airJumpVFX;
    public override void OnEnter()
    {
        base.OnEnter();
        playerController.CanAirJump = false;
        playerController.SetVelocityY(jumpForce);
        Instantiate(airJumpVFX, playerController.transform.position, Quaternion.identity);
    }
    public override void OnUpdate()
    {
        if (playerInput.StopJump || playerController.IsFalling)
        {
            playerStateMachine.ChangeState(typeof(PlayerStateFall));
        }
    }

    public override void OnFixedUpdate()
    {
        playerController.Move(speedInAir);
    }

}
