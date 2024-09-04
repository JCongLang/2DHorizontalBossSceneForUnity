using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Boss")]
public class FaceDirAction : EnemyAction
{
    public SharedGameObject player;
    public SharedVector3 sharedBossDirectionToPlayer;

    private Transform bossTransform; // Boss 的 Transform 组件
    private Transform playerTransform; // 玩家的 Transform 组件

    public override void OnAwake()
    {
        player.Value = GameObject.FindGameObjectWithTag("Player");
        // 获取 Boss 的 Transform 组件
        bossTransform = gameObject.transform;
    }

    public override void OnStart()
    {
        // 获取玩家的 Transform 组件
        if (player.Value != null)
        {
            playerTransform = player.Value.transform;
        }
    }

    public override TaskStatus OnUpdate()
    {
        if (playerTransform == null)
        {
            return TaskStatus.Failure; // 如果玩家未指定或未找到，返回任务失败
        }

        // 获取 Boss 到玩家的方向
        
        Vector3 direction = playerTransform.position - bossTransform.position;
        direction.z = 0f; // 因为在 2D 中不需要考虑 Z 轴

        if (direction.sqrMagnitude > 0.01f) // 确保方向不是零向量
        {
            // 使用 LookAt 方法使 Boss 面朝玩家
            // bossTransform.up = direction.normalized; // 这里用 transform.up 是因为在 2D 中通常使用 transform.up 来表示 Boss 的前方
            bossTransform.eulerAngles = new Vector3(0, direction.x < 0 ? 0 : 180, 0);
        }
        sharedBossDirectionToPlayer.Value = direction;
        return TaskStatus.Success; // 持续执行任务
    }
}
