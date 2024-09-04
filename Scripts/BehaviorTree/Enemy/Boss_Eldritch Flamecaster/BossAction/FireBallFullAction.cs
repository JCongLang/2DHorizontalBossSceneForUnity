// using BehaviorDesigner.Runtime.Tasks;
// using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
// using DG.Tweening;
// using UnityEngine;
// [TaskCategory("BossAttack")]
// public class FireBallFullAction : EnemyAction
// {
//     public Collider2D FireBallAreaCollider2D;
//     public AbstractProjectile FireBallPrefab;
//     public int FireBallCount = 4;
//     public float FireBallFallingIntervalTime = 0.5f;
//     public float FireBallLifetime = 3f; // 火球的生命周期
//
//     
//     
//     
//     public override TaskStatus OnUpdate()
//     {
//         var sequence = DOTween.Sequence();
//
//         for (int i = 0; i < FireBallCount; i++)
//         {
//             sequence.AppendCallback(FireBallFall);
//             sequence.AppendInterval(FireBallFallingIntervalTime);
//         }
//
//         sequence.OnComplete(() => {
//             return TaskStatus.Success;
//         });
//
//         return TaskStatus.Running;
//     }
//
//     private void FireBallFall()
//     {
//         var positionX = Random.Range(FireBallAreaCollider2D.bounds.min.x, FireBallAreaCollider2D.bounds.max.x);
//         var positionY = FireBallAreaCollider2D.bounds.min.y;
//         var FireBall = Object.Instantiate(FireBallPrefab, new Vector3(positionX, positionY),Quaternion.identity);
//         FireBall.SetForce(Vector2.zero);
//         
//         Destroy(FireBall.gameObject, FireBallLifetime);
//     }
// }
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;
using UnityEngine;

[TaskCategory("BossAttack")]
public class FireBallFullAction : EnemyAction
{
    public Collider2D FireBallAreaCollider2D;
    public AbstractProjectile FireBallPrefab;
    public int FireBallCount = 4;
    public float FireBallFallingIntervalTime = 0.5f;
    public float FireBallLifetime = 3f; // 火球的生命周期

    private bool isSequenceComplete = false; // 标志位，表示任务是否完成

    public override void OnStart()
    {
        var sequence = DOTween.Sequence();

        for (int i = 0; i < FireBallCount; i++)
        {
            sequence.AppendCallback(FireBallFall);
            sequence.AppendInterval(FireBallFallingIntervalTime);
        }

        sequence.OnComplete(() => {
            isSequenceComplete = true;
        });
    }

    public override TaskStatus OnUpdate()
    {
        if (isSequenceComplete)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }

    private void FireBallFall()
    {
        var positionX = Random.Range(FireBallAreaCollider2D.bounds.min.x, FireBallAreaCollider2D.bounds.max.x);
        var positionY = FireBallAreaCollider2D.bounds.min.y;
        var fireBall = Object.Instantiate(FireBallPrefab, new Vector3(positionX, positionY), Quaternion.identity);
        fireBall.SetForce(Vector2.zero);

        // 在 3 秒后销毁火球
        Object.Destroy(fireBall.gameObject, FireBallLifetime);
    }
}
