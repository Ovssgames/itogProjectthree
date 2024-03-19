using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerlevel : MonoBehaviour
{


    private ProgressPlus ProgressPlus;
    private AddKit Addkit;
    private PlayerHealth PlayerHealth;
    private BulletCaster BulletCaster;
    private Bullet Bullet;
    private GrenadeCaster GrenadeCaster;
    private Explosion Explosion;


    private void Start()
    {
        ProgressPlus = FindObjectOfType<ProgressPlus>();//опыт
        Addkit = FindObjectOfType<AddKit>();// xp
        PlayerHealth = FindObjectOfType<PlayerHealth>();
        BulletCaster = FindObjectOfType<BulletCaster>();
        Bullet = FindObjectOfType<Bullet>();
        GrenadeCaster = FindObjectOfType<GrenadeCaster>();
        Explosion = FindObjectOfType<Explosion>();
    }

    public void ProgressOpit()
    {
        ProgressPlus.progress *= 1.5f;
    }

    public void ProgressAddkit()
    {
        Addkit.healAmount *= 1.5f;
    }

    public void ProgressMaxXP()
    {
        PlayerHealth._maxValue *= 1.5f;
    }

    public void ProgressMaxBullet()
    {
        BulletCaster.maxKolvoBullet *= 2;
    }
    public void ProgressBulletTime()
    {
        BulletCaster._timeAnimation /= 1.5f;
    }
    public void ProgressDamageBullet()
    {
        Bullet.damage *= 1.5f;
    }
    public void ProgressGrenateOpen()
    {
        GrenadeCaster.grenadeOpen = true;

    }
    public void ProgressGrenatedamage()
    {

    }
    public void ProgressgrenateInv()
    {

    }
    public void ProgressRadius()
    {

    }
}
