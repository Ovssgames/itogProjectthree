using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator Animator;

    private EnemyDropProgress _enemyDropProgress;
    private EnemyDrop _EnemyDrop;
    private EnemyAI EnemyAI;
    private CapsuleCollider CapsuleCollider;
    


    private void Start()
    {
        _enemyDropProgress = GetComponent<EnemyDropProgress>();
        _EnemyDrop = GetComponent<EnemyDrop>();
        EnemyAI = GetComponent<EnemyAI>();
        CapsuleCollider = GetComponent<CapsuleCollider>();
    }




    // Update is called once per frame
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value < 0)
        {
            _enemyDropProgress.DropEnemyProgress();
            _EnemyDrop.DropDorp();
            Animator.SetTrigger("isDeath");
            _EnemyDrop.enabled = false;
            _enemyDropProgress.enabled = false;
            EnemyAI.enabled = false;
            CapsuleCollider.enabled = false;
            Invoke("DestroyEnemy", 20);
            GetComponent<NavMeshAgent>().enabled = false;
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
