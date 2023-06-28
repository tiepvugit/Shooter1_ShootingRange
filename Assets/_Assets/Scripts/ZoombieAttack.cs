using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZoombieAttack : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private Health _playerHealth;

    private bool _isAttacking = false;
    [SerializeField]
    private float _interval;
    private float _startTime;

    [SerializeField]
    private UnityEvent<int> _onHit;

    private void Start()
    {
        _startTime = float.MinValue;
    }
    public void Enable()
    {
        _isAttacking = true;
    }

    public void Disable()
    {
        _isAttacking = false;
    }

    private void Update()
    {
        if (_isAttacking)
        {
            StartAttack();
        }
    }

    private void StartAttack()
    {
        if (_interval > Time.time - _startTime)
            return;
        _startTime = Time.time;
        _animator.SetTrigger("attack");
    }

    

    private void OnAttack(int index)
    {
        print("OnAttack");
        _playerHealth.TakeDamage(_damage);
        PlayerUi.Instance.ShowScratch(index);
        //_onHit?.Invoke(index);
    }
}
