using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float speed = 2;
    public GameObject LevelMenu;
    public GameObject effectPrefab;

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

        effectPrefab.transform.localScale = new Vector3(t / 2.5f, t / 2.5f, t / 2.5f);
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
