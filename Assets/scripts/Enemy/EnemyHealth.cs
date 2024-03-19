using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;

    private EnemyDropProgress _enemyDropProgress;
    private EnemyDrop _EnemyDrop;

    private void Start()
    {
        _enemyDropProgress = GetComponent<EnemyDropProgress>();
        _EnemyDrop = GetComponent<EnemyDrop>();
    }




    // Update is called once per frame
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value < 0)
        {
            _enemyDropProgress.DropEnemyProgress();
            _EnemyDrop.DropDorp();
            Destroy(gameObject);
        }
    }
}
