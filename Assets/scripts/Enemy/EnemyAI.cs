using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float damage = 30;

    private NavMeshAgent _navMeshAgent;
    private PlayerHealth _playerHeltUp;
    private PlayerController PlayerController;
    private EnemyAI _enemyAI;

    private void Start()
    {
        NavGetComponent();
        _enemyAI = GetComponent<EnemyAI>();
    }

    private void Update()
    {
        AttackUp();
    }
    private void NavGetComponent()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PlayerController = FindObjectOfType<PlayerController>();
        _playerHeltUp = FindObjectOfType<PlayerHealth>();
    }

    void AttackUp()
    {
        _navMeshAgent.destination = PlayerController.transform.position;
        if ( _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _playerHeltUp.DealDamage(damage * Time.deltaTime);
        }
    }

}
