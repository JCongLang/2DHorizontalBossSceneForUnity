using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/JumpUp", fileName = "PlayerState_JumpUp")]
public class PlayerState_JumpUp : PlayerState
{
    [SerializeField] private float jumpForce = 7f;

    [SerializeField] private float moveSpeed = 5f;
    public override void Enter()
    {
        base.Enter();
        
        _player.SetVolocityY(jumpForce);
    }

    public override void LogicUpdate()
    {
        // Debug.Log("PlayerState_JumpUp");
        if (_playerInput.stopJump || _player.isFalling)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        if (_charcAttr.isHurt)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Hurt));
        }
    }

    public override void PhysicUpdate()
    {
        _player.Move(moveSpeed);
    }
}
