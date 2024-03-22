using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKit : MonoBehaviour
{
    private PlayerHealth _PlayerHealth;

    private void Start()
    {
        _PlayerHealth = FindObjectOfType<PlayerHealth>();
    }





    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        var playerHealt = other.GetComponent<PlayerHealth>();
        if (playerHealt != null)
        {
            var r = _PlayerHealth.healAmount;
            playerHealt.AddHealth(r);
            Destroy(gameObject);
        }
    }
}
