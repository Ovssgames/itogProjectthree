using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int lifetime;
    public float damage = 10;

    



    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", lifetime);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BulletFixedUpdate();
    }

    
    private void BulletFixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);     //движение пули по оси z
    }

    private void OnCollisionEnter(Collision collision)
    {
        Damage(collision);
        DestroyBullet();

    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void Damage(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            
            enemyHealth.DealDamage(damage);
        }
    }


}
