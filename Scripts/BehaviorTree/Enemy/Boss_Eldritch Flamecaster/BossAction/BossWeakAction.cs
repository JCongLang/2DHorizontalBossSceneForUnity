using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
[TaskCategory("Boss")]
public class BossWeakAction : EnemyAction
{
    public override void OnStart()
    {
        _animator.Play("Boss_Weak");
    }

    public override TaskStatus OnUpdate()
    {
        if (_enemy.currentHealth > 0)
        {
            return TaskStatus.Running;
        }
        return TaskStatus.Success;
    }
}
