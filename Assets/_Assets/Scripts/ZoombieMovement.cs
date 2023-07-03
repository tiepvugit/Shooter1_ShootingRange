using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZoombieMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _playerFoot;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private float reachingRadius;
    [SerializeField]
    private UnityEvent _onDestinationReached;
    [SerializeField]
    private UnityEvent _onStartMoving;

    private void Start() => _playerFoot = Player.Instance.PlayerFoot;

    private void Update()
    {
        float distance = Vector3.Distance(_playerFoot.position, transform.position);

        //print($"distance: {distance}  ---- position: {_playerFoot.position} - enemy: {transform.position}");
        if (distance > reachingRadius)
        {
            _onStartMoving?.Invoke();
            _agent.isStopped = false;
            _agent.SetDestination(_playerFoot.position);
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _onDestinationReached?.Invoke();
            _agent.isStopped = true;
            _animator.SetBool("isWalking", false);
        }
    }

    public void OnDeath()
    {
        enabled = false;
        _agent.isStopped = true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_playerFoot.position, 0.1f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
