using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealthPoint;
    private int healthPoint;
    [SerializeField]
    private Animator animator;
    public bool IsDead => healthPoint <= 0;

    private void Start() => healthPoint = maxHealthPoint;

    public void TakeDamage(int damage)
    {
        if (IsDead)
            return;
        healthPoint -= damage;
        if(IsDead)
        {
            Die();
        }
    }

    private void Die() => animator.SetTrigger("die");
}
