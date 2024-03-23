using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    public GameObject LevelMenu;

    private ProgressPlus ProgressPlus;
    private AddKit Addkit;
    private PlayerHealth PlayerHealth;
    private BulletCaster BulletCaster;
    private Bullet Bullet;
    private GrenadeCaster GrenadeCaster;
    private Explosion Explosion;
    private PlayerProgress PlayerProgress;



    private void Start()
    {

        ProgressPlus = FindObjectOfType<ProgressPlus>();//опыт
        Addkit = FindObjectOfType<AddKit>();// xp
        PlayerHealth = FindObjectOfType<PlayerHealth>();
        BulletCaster = FindObjectOfType<BulletCaster>();
        GrenadeCaster = FindObjectOfType<GrenadeCaster>();
        Explosion = FindObjectOfType<Explosion>();
        PlayerProgress = FindObjectOfType<PlayerProgress>();
    }

    private void Update()
    {
    }

    public void ProgressOpit()
    {
        cursorDisable();
        PlayerProgress.progress *= 2f;
        LevelMenu.SetActive(false);
    }

    public void ProgressAddkit()
    {
        cursorDisable();
        PlayerHealth.healAmount *= 1.5f;
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
        BulletCaster.time /= 1.5f;
        LevelMenu.SetActive(false);
    }
    public void ProgressDamageBullet()
    {
        cursorDisable();
        BulletCaster.damage *= 1.5f;
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
            GrenadeCaster.damage *= 1.5f;
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
    public void ProgressRadius()
    {
        if (GrenadeCaster.grenadeOpen == true)
        {
            cursorDisable();
            GrenadeCaster.maxSize *= 1.5f;
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
