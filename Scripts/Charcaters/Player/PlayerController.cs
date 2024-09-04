using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerGroundDetector _playerGroundDetector;
    
    private PlayerInput _playerInput;
    
    private Rigidbody2D _rigidbody2D;

    
    public bool canAirJump { get; set; } = true;
    
    
    public bool isGrounded => _playerGroundDetector.isGround;//触地状态
    
    public bool isFalling => _rigidbody2D.velocity.y < 0f && !isGrounded;
    public float moveSpeed => Mathf.Abs(_rigidbody2D.velocity.x);

    public static PlayerController Instance;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerGroundDetector = GetComponentInChildren<PlayerGroundDetector>();
        
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _playerInput.EnableGamePlayInput();
    }

    public void SetVolocity(Vector2 velocity)
    {
        _rigidbody2D.velocity = velocity;
    }
    
    public void SetVolocityX(float velocityX)
    {
        _rigidbody2D.velocity = new Vector2(velocityX, _rigidbody2D.velocity.y);
    }

    public void SetVolocityY(float velocityY)
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, velocityY);
    }

    public void Move(float speed)
    {
        //转向
        if (_playerInput.Move)
        {
            // transform.localScale = new Vector3(_playerInput.AxisX * transform.localScale.x,transform.localScale.y,1);
            transform.eulerAngles = new Vector3(0, _playerInput.AxisX > 0 ? 0 : 180, 0);
        }
        SetVolocityX(speed * _playerInput.AxisX);
    }
    
    
    
}
