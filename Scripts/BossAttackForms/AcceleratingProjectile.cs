using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratingProjectile : AbstractProjectile
{
    public float speedOfProjectile = 5.0f;

    public Vector3 direction;
    public Vector3 velocity;

    private void Start()
    {
        Invoke(nameof(DestroyProjectile), 3.0f);
    }

    public override void SetForce(Vector2 force)
    {
        this.force = force;
        direction = force.normalized;
    }

    private void Update()
    {
        velocity += direction * speedOfProjectile * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}
