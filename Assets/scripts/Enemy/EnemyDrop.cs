using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameObject addkitDropPrefab;
    public GameObject grenadeDropPrefab;
    public int ChanseAddkit = 65;


    private float _randomayzer;
    private GrenadeCaster _grenadeCaster;
    private void Start()
    {
        _grenadeCaster = FindObjectOfType<GrenadeCaster>();
    }

    public void DropDorp()
    {
        _randomayzer = Random.Range(0, 10);
        Debug.Log("yes");
        if(_randomayzer > 5)
        {
            var randomm = Random.Range(0, 100);
            if (randomm >= ChanseAddkit && _grenadeCaster.grenadeOpen)
            {
                Instantiate(grenadeDropPrefab, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(addkitDropPrefab, transform.position, transform.rotation);
            }
        }
    }

}
