using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float damage = 30;
    public float vievAngle;
    public Animator Animator;

    private NavMeshAgent _navMeshAgent;
    private PlayerHealth _playerHeltUp;
    private PlayerController PlayerController;
    private EnemyAI _enemyAI;
    private bool _isRayDirection;

    private void Start()
    {
        NavGetComponent();
        _enemyAI = GetComponent<EnemyAI>();
    }
    private void NavGetComponent()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PlayerController = FindObjectOfType<PlayerController>();
        _playerHeltUp = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        AttackUp();
        Raycastplayer();
    }

    private void Raycastplayer()
    {
        var direction = PlayerController.transform.position - transform.position;

        _isRayDirection = false;
        if(Vector3.Angle(transform.forward, direction) < vievAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if(hit.collider.gameObject == PlayerController.gameObject)
                {
                    _isRayDirection = true;
                }
            }
        }
    }


    void AttackUp()
    {
        _navMeshAgent.destination = PlayerController.transform.position;
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _isRayDirection)
        {
            _playerHeltUp.DealDamage(damage * Time.deltaTime);
            Animator.SetBool("isAttack", true);
        }
        else
        {
            Animator.SetBool("isAttack", false);
        }
    }



}
