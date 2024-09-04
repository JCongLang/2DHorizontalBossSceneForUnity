using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    [SerializeField] private float deceleration = 6f;
    public override void Enter()
    {
        // _animator.Play("Player_Idle");
        base.Enter();
        // _player.SetVolocityX(0f);
        currentSpeed = _player.moveSpeed;
    }

    public override void LogicUpdate()
    {
        // Debug.Log("PlayerState_Idle");
        if (_playerInput.Move)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Run));
        }
        if (_playerInput.Jump)
        {
            _stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        if (! _player.isGrounded)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        if (_charcAttr.isHurt)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Hurt));
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f,deceleration * Time.deltaTime);
    }

    public override void PhysicUpdate()
    {
        _player.SetVolocityX(currentSpeed * _player.transform.localScale.x);
    }
}
