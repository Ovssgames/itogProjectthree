using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> PatrolPoint;
    public PlayerController Player;
    public float vievAngle;
    public float damage = 30;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHeltUp;

    private void Start()
    {
        NavGetComponent();
        PickPatroolPoint();
    }

    private void Update()
    {
        PatrolUp();
        Raycast();
        AttackUp();
    }

    void AttackUp()
    {
        if (_isPlayerNoticed &&  _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _playerHeltUp.DealDamage(damage * Time.deltaTime);
        }
    }

    private void NavGetComponent()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHeltUp = Player.GetComponent<PlayerHealth>();
    }

    private void PickPatroolPoint()
    {
            _navMeshAgent.destination = PatrolPoint[Random.Range(0, PatrolPoint.Count)].position;
    }


    private void PatrolUp()
    {
        if (!_isPlayerNoticed)
        {
            if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickPatroolPoint();
            }
        }
    }

    private void Raycast()
    {
        var direction = Player.transform.position - transform.position;

        _isPlayerNoticed = false;
        if(Vector3.Angle(transform.forward, direction) < vievAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }

        if(_isPlayerNoticed)
        {
            _navMeshAgent.destination = Player.transform.position;
        }
        

    }
}
