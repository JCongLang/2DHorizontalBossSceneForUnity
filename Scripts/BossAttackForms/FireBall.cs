using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : AbstractProjectile
{
    public override void SetForce(Vector2 force)
    {
        this.force = force;
        GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }
}
