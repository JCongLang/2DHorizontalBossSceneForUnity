using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
[TaskCategory("Boss")]
public class BossResetHealthAction : EnemyAction
{
    public int rehealth;
    public override TaskStatus OnUpdate()
    {
        _enemy.currentHealth = rehealth;
        return TaskStatus.Success;
    }
}
