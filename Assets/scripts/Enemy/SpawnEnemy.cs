using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float time;

    private float _time;

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= time)
        {
            _time = 0;
            Instantiate(EnemyPrefab, transform.position, transform.rotation);
        }

    }
}
