using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class isHealthUnderContional : EnemyConditional
{
    public SharedInt healthThreshold;

    public override TaskStatus OnUpdate()
    {
        return _enemy.currentHealth < healthThreshold.Value ? TaskStatus.Success : TaskStatus.Failure;
    }
    
}
