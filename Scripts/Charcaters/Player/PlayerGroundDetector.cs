using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 0.1f;

    [SerializeField] private LayerMask groundLayer;

    private Collider2D[] colliders = new Collider2D[1];
    
    // public bool isGround => Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, colliders, groundLayer) != 0;
    public bool isGround => Physics2D.OverlapCircleNonAlloc(transform.position, detectionRadius, colliders,groundLayer) != 0;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
