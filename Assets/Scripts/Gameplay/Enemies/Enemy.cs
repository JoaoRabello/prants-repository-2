using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected GameObject _target;
    [SerializeField] protected float _maxHealth;

    protected float _currentHealth;

    public delegate void OnDieDelegate();
    public event OnDieDelegate OnDieEvent;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void SetTarget(GameObject newTarget)
    {
        _target = newTarget;
    }

    #region Health Control
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TakeDamage(1);
        }
    }
    
    private void Die()
    {
        OnDieEvent?.Invoke();
        Destroy(gameObject);
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth > damageAmount)
        {
            _currentHealth -= damageAmount;
        }
        else
        {
            Die();
        }
    }
    #endregion
}
