using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class DashTowardsPlayer : EnemyAction
{
    public float dashSpeed = 20f;
    public Transform player;
    public override void OnStart()
    {
        _animator.Play("Boss_Attack_2");
        player = _playerController.transform;
    }

    public override TaskStatus OnUpdate()
    {
        if (player == null) return TaskStatus.Failure;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * dashSpeed * Time.deltaTime;

        return TaskStatus.Success;
    }
}
