using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected GameObject _target;

    public delegate void OnDieDelegate();
    public event OnDieDelegate OnDieEvent;

    public void SetTarget(GameObject newTarget)
    {
        _target = newTarget;
    }
    
    private void Die()
    {
        OnDieEvent?.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Die();
        }
    }
}
