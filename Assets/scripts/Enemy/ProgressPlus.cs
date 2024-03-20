using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressPlus : MonoBehaviour
{
    public GameObject Sphere;

    private PlayerProgress _playerProgress;


    private void Start()
    {
        _playerProgress = FindObjectOfType<PlayerProgress>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var isPlayer = other.GetComponent<PlayerProgress>();
        float e = _playerProgress.progress;
        if (isPlayer != null)
        {
            _playerProgress.AddExperience(e);
            Destroy(gameObject);
            Destroy(Sphere);
        }
    }
}
