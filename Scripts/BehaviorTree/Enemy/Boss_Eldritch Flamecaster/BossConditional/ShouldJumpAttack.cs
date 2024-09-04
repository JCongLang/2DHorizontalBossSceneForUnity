using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class ShouldJumpAttack : EnemyConditional
{
    public float attackRange = 10f;
    public Transform player;

    public override void OnStart()
    {
        player = _playerController.transform;
    }

    public override TaskStatus OnUpdate()
    {
        if (player == null) return TaskStatus.Failure;
        
        float distance = Vector2.Distance(transform.position, player.position);
        return distance <= attackRange ? TaskStatus.Success : TaskStatus.Failure;
    }
}
