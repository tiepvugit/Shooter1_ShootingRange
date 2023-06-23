using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    private void Update()
    {
        float distance = Vector3.Distance(_playerFoot.position, transform.position);
        if (distance > reachingRadius)
        {
            _agent.isStopped = false;
            _agent.SetDestination(_playerFoot.position);
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _agent.isStopped = true;
            _animator.SetBool("IsWalking", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_playerFoot.position, 0.1f);
    }
}
