using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody grenadePrefab;
    public Transform handGun;
    public float force;

    private Rigidbody _addForvard;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = handGun.position;
            grenade.GetComponent<Rigidbody>().AddForce(handGun.forward * force);
        }
    }
}
