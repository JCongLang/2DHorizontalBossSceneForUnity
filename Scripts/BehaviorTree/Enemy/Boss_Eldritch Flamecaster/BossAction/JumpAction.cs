using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;
using UnityEngine;
[TaskCategory("Boss")]
public class JumpAction : EnemyAction
{
    [SerializeField] private float horizontalForce;
    [SerializeField] private float jumpForce;

    public float startTime;
    public float jumpTime => _animator.GetCurrentAnimatorStateInfo(0).length;
    
    private bool isGrounded;

    private Tween startJumpTween;
    private Tween jumpTween;

    public override void OnStart()
    {
        startJumpTween = DOVirtual.DelayedCall(startTime, StartJump, false);
        
        _animator.Play("Boss_Jump");
        
    }

    private void StartJump()
    {
        float Dir = _playerController.transform.position.x < transform.position.x ? -1 : 1;
        _rigidbody2D.AddForce(new Vector2(horizontalForce * Dir, jumpForce), ForceMode2D.Impulse);

        jumpTween = DOVirtual.DelayedCall(
            jumpTime,
            () => { isGrounded = true;},
            false
        );
    }

    public override void OnEnd()
    {
        startJumpTween.Kill();
        jumpTween.Kill();
        isGrounded = false;
    }
    
    public override TaskStatus OnUpdate()
    {
        return isGrounded ? TaskStatus.Success : TaskStatus.Running;
    }
}
