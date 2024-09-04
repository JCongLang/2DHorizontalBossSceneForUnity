using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  AbstractProjectile : MonoBehaviour
{
    public float damage;
    public ParticleSystem explosionEffect;
    public AudioClip sound;
    
    public GameObject shooter { get; set; }
    
    protected Vector2 force;

    public event Action<AbstractProjectile> OnProjectileDestroyed;

    public abstract void SetForce(Vector2 force);

    protected void DestroyProjectile()
    {
        OnProjectileDestroyed?.Invoke(this);
        if (sound != null)
        {
            //TODO SoundManager Effect
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == shooter)
        {
            return;
        }

        var _player = collision.GetComponent<BaseCharcAttr>();
        
        _player.isHurt = true;
        
        if (_player != null)
        {
            Vector2 force = this.force.normalized;
            //TODO Player收到伤害
        }
        DestroyProjectile();
    }
}
