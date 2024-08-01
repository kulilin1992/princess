using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/JupmUp", fileName = "PlayerStateJupmUp")]
public class PlayerStateJumpUp : PlayerState
{

    [SerializeField] float jumpForce = 10f;
    public override void OnEnter()
    {
        base.OnEnter();
        playerController.SetVelocityY(jumpForce);
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
