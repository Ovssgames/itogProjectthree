using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    public GameObject explosionprefab;
    public GameObject effectPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", delay);
    }

    private void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(explosionprefab);
        explosion.transform.position = transform.position;
        var effect = Instantiate(effectPrefab);
        effect.transform.position = transform.position;
    }
}
