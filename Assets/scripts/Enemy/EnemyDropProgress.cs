using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropProgress : MonoBehaviour
{
    public List<Transform> spawnProgress;
    public GameObject progressPrefab;
    public float force;

    public void DropEnemyProgress()
    {
        for(int i = 0; i < spawnProgress.Count; i++)
        {
            var progress = Instantiate(progressPrefab, spawnProgress[i].position, spawnProgress[i].rotation);
            progress.GetComponent<Rigidbody>().AddForce(spawnProgress[i].forward * Random.Range(force * 2f,force / 2f));
        }
    }
}
