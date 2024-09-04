using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Boss")]
public class JumpVerticalAction : EnemyAction
{
    public float jumpHeight = 10f;
    public float jumpSpeed = 5f;

    private bool isJumping = false;
    private float initialY;
    private float targetY;

    public override void OnStart()
    {
        if (!isJumping)
        {
            _animator.Play("Boss_Jump");
            isJumping = true;
            initialY = transform.position.y;
            // targetY = initialY + jumpHeight;
            targetY = 0.7f;
        }
    }

    public override TaskStatus OnUpdate()
    {
        if (!isJumping) return TaskStatus.Success;

        float newY = Mathf.MoveTowards(transform.position.y, targetY, jumpSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        if (Mathf.Abs(transform.position.y - targetY) < 0.1f)
        {
            isJumping = false;
            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }

    public override void OnEnd()
    {
        isJumping = false;  // 重置跳跃状态
    }
}
