using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputAction _playerInputAction;

    private Vector2 axes => _playerInputAction.GamePlay.Move.ReadValue<Vector2>();

    public bool Jump => _playerInputAction.GamePlay.Jump.WasPressedThisFrame();
    public bool stopJump => _playerInputAction.GamePlay.Jump.WasReleasedThisFrame();
    public bool Move => AxisX != 0f;

    public float AxisX => axes.x;
    private void Awake()
    {
        _playerInputAction = new PlayerInputAction();
    }

    public void EnableGamePlayInput()
    {
        _playerInputAction.GamePlay.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void DisEnableGamePlayInput()
    {
        _playerInputAction.GamePlay.Disable();
        Cursor.lockState = CursorLockMode.Locked;
    }
}
