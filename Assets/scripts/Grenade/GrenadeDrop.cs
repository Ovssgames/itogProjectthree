using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDrop : MonoBehaviour
{
    private GrenadeCaster _grenadeCaster;

    private void Start()
    {
        _grenadeCaster = FindObjectOfType<GrenadeCaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var y = other.GetComponent<GrenadeCaster>();
        if (y != null)
        {
        _grenadeCaster.kolvoGrenade++;
        Destroy(gameObject);
        }
    }
}
