using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCaster : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform BulletGun;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletCast();
    }

    private void BulletCast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(BulletPrefab, BulletGun.position, BulletGun.rotation);
            
        }
    }
}
