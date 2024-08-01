using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float time;

    private float _time;
    private float _timeSpawn;

    private void Start()
    {
        Instantiate(EnemyPrefab, transform.position, transform.rotation);
    }
    void Update()
    {
        _timeSpawn += Time.deltaTime;
        if (_timeSpawn > 120)
        {
            _timeSpawn = 0;
            time *= 0.75f;
        }

        _time += Time.deltaTime;
        if (_time >= time)
        {
            _time = 0;
            Instantiate(EnemyPrefab, transform.position, transform.rotation);
        }

    }
}
