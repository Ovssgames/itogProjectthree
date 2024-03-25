using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletCaster : MonoBehaviour
{
    public Bullet BulletPrefab;
    public Transform BulletGun;
    public Animator animator;
    public float time;
    public AudioSource shoot;
    public AudioSource reloadGun;

    public float timeAnimation;
    public int kolvoBullet;
    public int maxKolvoBullet;
    public TextMeshProUGUI textR;
    public float damage = 10;
    public float _timeAnimation;


    private float _time;
    private bool _isReload = false;

    private CameraCol CameraCol;

    private void Start()
    {
        maxKolvoBullet = 10;
        time = 0.3f;
        _time = time;
        damage = 10;
    }

    void Update()
    {
        BulletCast();
        ReloadGun();
    }


    private void ReloadGun()
    {
        _timeAnimation += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R) && kolvoBullet<maxKolvoBullet)
        {
            _timeAnimation = 0;
            _isReload = true;
            animator.SetTrigger("reload");
            reloadGun.Play();
        }
        if (_timeAnimation >= timeAnimation && _isReload == true)
        {
            kolvoBullet = maxKolvoBullet;
            _timeAnimation = 0;
            _isReload = false;
        }

        textR.text = kolvoBullet + "/" + maxKolvoBullet;
    }

    private void BulletCast()
    {
        _time += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) && _time >= time && kolvoBullet > 0 && !_isReload)
        {
            _time = 0;
            kolvoBullet--;

            shoot.Play();

            Instantiate(BulletPrefab, BulletGun.position, BulletGun.rotation);
            
            animator.SetTrigger("Shoot");
        }
    }
}
