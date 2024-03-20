using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float speed = 2;
    public GameObject LevelMenu;

    private Vector3 _maxVector3Size;
    private GrenadeCaster GrenadeCaster;

    // Start is called before the first frame update
    void Start()
    {
        GrenadeCaster = FindObjectOfType<GrenadeCaster>();
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speed;

        var t = GrenadeCaster.maxSize;
        if(transform.localScale.z > t)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealt = other.GetComponent<PlayerHealth>();
        float grenadeDamage = GrenadeCaster.damage;

        if (playerHealt != null)
        {
            playerHealt.DealDamage(grenadeDamage);
        }

        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(grenadeDamage);
        }
    }
}
