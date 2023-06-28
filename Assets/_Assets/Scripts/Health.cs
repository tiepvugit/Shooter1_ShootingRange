using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxHealthPoint = 100;
    [SerializeField]
    private int _healthPoint = 0;
    [SerializeField]
    private Animator _animator;
    public bool IsDead => _healthPoint <= 0;

    [SerializeField]
    private UnityEvent onDeath;


    private void Start() => _healthPoint = _maxHealthPoint;

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            Debug.LogWarning($"invalid damage: {damage}");
            return;
        }
        if (IsDead)
            return;
        Debug.LogWarning($"deal damage: {damage}");
        _healthPoint = Math.Clamp(_healthPoint - damage, 0, _maxHealthPoint);
        if (IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        if(_animator)
        _animator?.SetTrigger("die");
        onDeath?.Invoke();
    }
}
