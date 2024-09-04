using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharcAttr : MonoBehaviour
{
    [Header("状态")]
    public bool isHurt = false;
    
    [Header("基本属性")] 
    public float maxHealth;
    public float currentHealth;


    private PlayerController _playerController;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage()
    {
        if (isHurt)
        {
            _playerController.SetVolocityX(-1 * _playerInput.AxisX);//受伤被击退
            
            StartCoroutine(HurtCoroutine());
        }
    }
    
    public IEnumerator HurtCoroutine()
    {
        // 等待0.5秒
        yield return new WaitForSeconds(0.5f);
        isHurt = false;
    }
}
