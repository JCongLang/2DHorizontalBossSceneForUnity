using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Hurt", fileName = "PlayerState_Hurt")]
public class PlayerState_Hurt : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        _charcAttr.TakeDamage();
    }

    public override void LogicUpdate()
    {
        
        if (!_charcAttr.isHurt)
        {
            _stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }

    public override void PhysicUpdate()
    {
        
    }
    
}
