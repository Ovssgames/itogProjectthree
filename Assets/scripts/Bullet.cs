using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int lifetime;


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
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
