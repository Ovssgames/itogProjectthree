using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCaster : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform BulletGun;
    public Animator animator;
    public float time;

    private float _time;
    
    private CameraCol CameraCol;

    private void Start()
    {
        _time = time;
    }

    void Update()
    {
        BulletCast();
    }

    private void BulletCast()
    {
        _time += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) && _time >= time)
        {
            _time = 0;
            Instantiate(BulletPrefab, BulletGun.position, BulletGun.rotation);
            animator.SetTrigger("Shoot");
        }
    }
}
