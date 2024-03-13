using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKit : MonoBehaviour
{
    public float healAmount = 50;



    



    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        var playerHealt = other.GetComponent<PlayerHealth>();
        if (playerHealt != null)
        {
            playerHealt.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
