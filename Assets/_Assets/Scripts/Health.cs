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
    [SerializeField]
    private UnityEvent _onDeath;
    [SerializeField]
    private UnityEvent<int, int> _onHealthChanged;
    [SerializeField]
    private UnityEvent _onTakeDamage;

    public bool IsDead => HealthPoint <= 0;

    public int HealthPoint
    {
        get => _healthPoint; set
        {
            _healthPoint = value;
            _onHealthChanged?.Invoke(_healthPoint, _maxHealthPoint);
        }
    }


    private void Start() => HealthPoint = _maxHealthPoint;

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            Debug.LogWarning($"invalid damage: {damage}");
            return;
        }
        if (IsDead)
            return;
        _onTakeDamage?.Invoke();
        Debug.LogWarning($"deal damage: {damage}");
        HealthPoint = Math.Clamp(HealthPoint - damage, 0, _maxHealthPoint);
        if (IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        if (_animator)
            _animator?.SetTrigger("die");
        _onDeath?.Invoke();
    }
}
