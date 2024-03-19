using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage = 50;
    public float maxSize = 5;
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
        if(transform.localScale.z > maxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealt = other.GetComponent<PlayerHealth>();
        if (playerHealt != null)
        {
            playerHealt.DealDamage(damage);
        }

        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }


    public void ProgressRadius()
    {
        if (GrenadeCaster.grenadeOpen == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
            maxSize *= 1.5f;
            LevelMenu.SetActive(false);

        }
        else
        {

        }
    }

    public void ProgressGrenatedamage()
    {
        if (GrenadeCaster.grenadeOpen == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
            damage *= 1.5f;
            LevelMenu.SetActive(false);

        }
        else
        {

        }
    }
}
