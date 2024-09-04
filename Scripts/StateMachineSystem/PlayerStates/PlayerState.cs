using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    [SerializeField] private string stateName;
    private int hashState;
    [SerializeField] private float transitionDuration = 0.5f;
    
    protected float currentSpeed;
    
    protected Animator _animator;
    protected PlayerController _player;
    protected BaseCharcAttr _charcAttr;
    protected PlayerStateMachine _stateMachine;
    protected PlayerInput _playerInput;
    
    //动画是否播放结束的检测
    protected bool isAnimationFinished => stateDuration >= _animator.GetCurrentAnimatorStateInfo(0).length;
    protected float stateDuration => Time.time - stateStartTime;
    private float stateStartTime;

    public void Initialize(Animator animator, PlayerController player, BaseCharcAttr charcAttr, PlayerInput playerInput, PlayerStateMachine stateMachine)
    {
        this._animator = animator;
        this._player = player;
        this._charcAttr = charcAttr;
        this._stateMachine = stateMachine;
        this._playerInput = playerInput;
    }

    private void OnEnable()
    {
        hashState = Animator.StringToHash(stateName);
    }

    public virtual void Enter()
    {
        _animator.CrossFade(hashState, transitionDuration);

        stateStartTime = Time.time;
    }

    public virtual void Exit()
    {
        
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
