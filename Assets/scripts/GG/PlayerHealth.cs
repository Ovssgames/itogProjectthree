using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;

    public GameObject gameplayUI;
    public GameObject GameOverScreen;

    private float _maxValue;

    private void Start()
    {
        gameplayUI.SetActive(true);
        _maxValue = value;
        DrawHealtBar();
    }

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value < 0)
        {
            playerIsDead();
        }
        DrawHealtBar();
        
    }

    private void playerIsDead()
    {
            gameplayUI.SetActive(false);
            GameOverScreen.SetActive(true);

            GetComponent<PlayerController>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            GetComponent<BulletCaster>().enabled = false;
    }

    private void DrawHealtBar()
    {
        valueRectTransform.anchorMax =new Vector2(value/_maxValue , 1);
    }
    public void AddHealth(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value, 0, _maxValue);
        DrawHealtBar();
    }
}
