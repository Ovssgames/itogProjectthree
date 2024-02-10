using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> PatrolPoint;

    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        PickPatroolPoint();
    }

    private void Update()
    {
        if(_navMeshAgent.remainingDistance == 0)
        {
            PickPatroolPoint();
        }
    }

    private void PickPatroolPoint()
    {
            _navMeshAgent.destination = PatrolPoint[Random.Range(0, PatrolPoint.Count)].position;
    }
}
