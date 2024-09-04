
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
[TaskCategory("Boss")]
public class EnemyAction : Action
{
    protected Rigidbody2D _rigidbody2D;
    protected Animator _animator;
    protected PlayerController _playerController;
    protected Enemy _enemy;
    public override void OnAwake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponentInChildren<Animator>();
        _playerController = PlayerController.Instance;
        _enemy = GetComponent<Enemy>();
    }
    
}
