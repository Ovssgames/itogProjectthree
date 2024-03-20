using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public RectTransform experienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP;
    public GameObject CanvasLevelMenu;
    public float progress = 20;


    private int _levelValue = 1;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;


    private void Update()
    {
        DrawUI();
    }

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;

        if(_experienceCurrentValue >= _experienceTargetValue)
        {
            _levelValue++;
            _experienceCurrentValue = 0;
            _experienceTargetValue *= 1.5f;

            CanvasLevelMenu.SetActive(true);


            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0;
        }
    }

    private void DrawUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString(); 
    }
}

