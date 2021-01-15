using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walker : Enemy
{
    [SerializeField] private NavMeshAgent _navMeshAgent;

    void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        _navMeshAgent.SetDestination(_target.transform.position);
    }
}
