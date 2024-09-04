using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    // public PlayerState_Idle _playerStateIdle;
    // public PlayerState_Run _playerStateRun;
    [SerializeField] PlayerState[] _playerState;
    private Animator _animator;
    protected BaseCharcAttr _charcAttr;
    private PlayerInput _playerInput;
    private PlayerController _playerController;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        
        stateTable = new Dictionary<Type, IState>(_playerState.Length);

        _playerInput = GetComponent<PlayerInput>();

        _playerController = GetComponent<PlayerController>();

        _charcAttr = GetComponent<BaseCharcAttr>();
        
        // Do Player states initialization here
        // _playerStateIdle.Initialize(_animator,this);
        // _playerStateRun.Initialize(_animator,this);
        foreach (PlayerState playerState in _playerState)
        {
            playerState.Initialize(_animator, _playerController, _charcAttr, _playerInput, this);
            stateTable.Add(playerState.GetType(), playerState);
        }
        
    }
    private void Start()
    {
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }
}
