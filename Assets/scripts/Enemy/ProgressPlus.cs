using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressPlus : MonoBehaviour
{
    public float progress;
    public GameObject Sphere;

    private PlayerProgress _playerProgress;

    private void Start()
    {
        _playerProgress = FindObjectOfType<PlayerProgress>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var isPlayer = other.GetComponent<PlayerProgress>();
        if (isPlayer != null)
        {
            _playerProgress.AddExperience(progress);
            Destroy(gameObject);
            Destroy(Sphere);
        }
    }
}
