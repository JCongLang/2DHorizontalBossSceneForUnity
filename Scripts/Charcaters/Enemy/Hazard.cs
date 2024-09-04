using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCollision(other.gameObject);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        CheckCollision(other.gameObject);
    }

    private void CheckCollision(GameObject otherGameObject)
    {
        if (otherGameObject.CompareTag("Player"))
        {
            var playerAttr = otherGameObject.GetComponent<BaseCharcAttr>();
            playerAttr.TakeDamage();
        }
    }
}
