using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField] private float stiffTime = 0.2f;
    public override void Enter()
    {
        base.Enter();
        
        _player.SetVolocity(Vector2.zero);
        _player.canAirJump = true;
    }

    public override void LogicUpdate()
    {
        // Debug.Log("PlayerState_Land");
        if (_playerInput.Jump)
        {
            _stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        if (stateDuration < stiffTime)
        {
            return;
        }
        if (_playerInput.Move)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Run));
        }
        if (isAnimationFinished)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if (_charcAttr.isHurt)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Hurt));
        }
    }
}
