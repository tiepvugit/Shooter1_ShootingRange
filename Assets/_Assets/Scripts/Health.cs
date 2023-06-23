using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealthPoint;
    [SerializeField]
    private int healthPoint;
    [SerializeField]
    private Animator animator;
    public bool IsDead => healthPoint <= 0;

    [SerializeField]
    private UnityEvent onDeath;


    private void Start() => healthPoint = maxHealthPoint;

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
        healthPoint = Math.Clamp(healthPoint - damage, 0, maxHealthPoint);
        if (IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");
        onDeath?.Invoke();
    }
}
