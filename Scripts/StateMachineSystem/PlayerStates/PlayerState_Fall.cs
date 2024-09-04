using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
    [SerializeField] private AnimationCurve speedCurve;
    
    [SerializeField] private float moveSpeed = 3f;
    public override void LogicUpdate()
    {
        // Debug.Log("PlayerState_Fall");
        if (_player.isGrounded)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Land));
        }
        if (_playerInput.Jump)
        {
            //SwithState2AirJump
            if (_player.canAirJump)
            {
                _stateMachine.SwitchState(typeof(PlayerState_AirJump));
            }
        }
        if (_charcAttr.isHurt)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Hurt));
        }
    }

    public override void PhysicUpdate()
    {
        _player.Move(moveSpeed);
        _player.SetVolocityY(speedCurve.Evaluate(stateDuration));
    }
}
