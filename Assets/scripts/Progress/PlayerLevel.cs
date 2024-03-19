using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{

    private ProgressPlus ProgressPlus;
    private AddKit Addkit;
    private PlayerHealth PlayerHealth;
    private BulletCaster BulletCaster;
    private Bullet Bullet;
    private GrenadeCaster GrenadeCaster;
    private Explosion Explosion;

    public GameObject LevelMenu;

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
        cursorDisable();
        ProgressPlus.progress *= 2f;
        LevelMenu.SetActive(false);
    }

    public void ProgressAddkit()
    {
        cursorDisable();
        Addkit.healAmount *= 1.5f;
        LevelMenu.SetActive(false);
    }

    public void ProgressMaxXP()
    {
        cursorDisable();
        PlayerHealth._maxValue *= 1.5f;
        LevelMenu.SetActive(false);
    }

    public void ProgressMaxBullet()
    {
        cursorDisable();
        BulletCaster.maxKolvoBullet *= 2;
        LevelMenu.SetActive(false);
    }
    public void ProgressBulletTime()
    {
        cursorDisable();
        BulletCaster._timeAnimation /= 1.5f;
        LevelMenu.SetActive(false);
    }
    public void ProgressDamageBullet()
    {
        cursorDisable();
        Bullet.Mndamage(1.5f);
        LevelMenu.SetActive(false);
    }
    public void ProgressGrenateOpen()
    {
        if (GrenadeCaster.grenadeOpen == false)
        {
            cursorDisable();
            GrenadeCaster.grenadeOpen = true;
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
            cursorDisable();
            Explosion.damage *= 1.5f;
            LevelMenu.SetActive(false);

        }
        else
        {

        }
    }
    public void ProgressgrenateInv()
    {
        if (GrenadeCaster.grenadeOpen == true)
        {
            cursorDisable();
            GrenadeCaster.maxGremade *= 2;
            LevelMenu.SetActive(false);
        }
        else
        {

        }
    }

    private void cursorDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;

    }
}
