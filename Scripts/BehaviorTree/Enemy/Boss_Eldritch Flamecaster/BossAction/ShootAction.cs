using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
[TaskCategory("BossAttack")]
public class ShootAction : EnemyAction
{
    public List<Weapon> weapons;
    public SharedVector3 sharedBossDirectionToPlayer;

    public override TaskStatus OnUpdate()
    {
        foreach (var weapon in weapons)
        {
            var projectile = Object.Instantiate(weapon._projectileProfab, weapon.weaponTransform.position, Quaternion.identity);
            
            projectile.shooter = gameObject;

            var force = new Vector2( -1 * weapon.hForce * transform.localScale.x * sharedBossDirectionToPlayer.Value.x, weapon.vForce);
            
            projectile.SetForce(force);
        }

        return TaskStatus.Success;
    }
}
