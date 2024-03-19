using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody grenadePrefab;
    public Transform handGun;
    public float force;
    public Animator animator;
    public bool grenadeOpen = false;
    public TextMeshProUGUI textGrenade;

    private Rigidbody _addForvard;

    public int kolvoGrenade;
    public int maxGremade = 3;

    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && Input.GetMouseButton(1) && grenadeOpen && kolvoGrenade > 0)
        {
            kolvoGrenade--;

            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = handGun.position;
            grenade.GetComponent<Rigidbody>().AddForce(handGun.forward * force);
            animator.SetTrigger("Shoot");
        }

        grenadeInv();
    }


    private void grenadeInv()
    {
        if (kolvoGrenade > maxGremade) kolvoGrenade = maxGremade;

        textGrenade.text = kolvoGrenade + "/" + maxGremade;
    }
}
