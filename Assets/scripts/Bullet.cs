using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
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

    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
