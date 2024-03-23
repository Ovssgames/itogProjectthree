using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;
    public float healAmount = 50;

    public GameObject gameplayUI;
    public GameObject GameOverScreen;
    public Animator animator;


    public float _maxValue;

    private void Start()
    {
        healAmount = 50;
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
            animator.SetTrigger("death");
            animator.SetLayerWeight(1, 0f);
            animator.SetLayerWeight(2, 0f);
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
