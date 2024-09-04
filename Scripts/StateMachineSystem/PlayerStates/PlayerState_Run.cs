using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{
    [SerializeField] float runSpeed = 0.5f;
    [SerializeField] private float acceleration = 5f;
    public override void Enter()
    {
        // _animator.Play("Player_Run");
        base.Enter();
        currentSpeed = _player.moveSpeed;
    }

    public override void LogicUpdate()
    {
        // Debug.Log("PlayerState_Run");
        if (!(_playerInput.Move))
        {
            _stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if (_playerInput.Jump && !_charcAttr.isHurt)
        {
            _stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        if (!_player.isGrounded)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        if (_charcAttr.isHurt)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Hurt));
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);
    }

    public override void PhysicUpdate()
    {
        _player.Move(currentSpeed);
    }
}
