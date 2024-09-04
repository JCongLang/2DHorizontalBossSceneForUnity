using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalCheck : MonoBehaviour
{
    private CapsuleCollider2D coll;
    
    [Header("检测参数")] 
    public float checkRaduis;
    public LayerMask groundLayer;
    public Vector2 bottomOffset;
    
    [Header("状态")]
    public bool isGround;
    private void Awake()
    {
        coll = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        Check();
    }

    public void Check()
    {
        //检测地面
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRaduis, groundLayer);
    }
    
    private void OnDrawGizmosSelected()//绘制physicscheck的检测范围
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRaduis);
    }
}
