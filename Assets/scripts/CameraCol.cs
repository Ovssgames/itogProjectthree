using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCol : MonoBehaviour
{
    public Transform Camera;

    private Vector3 _defoltCameraPosition;


    // Update is called once per frame
    void Update()
    {
        var ray = Camera.position - transform.position;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, ray, out hit))
        {
            if (hit.collider.gameObject)
            {
                Camera.position = hit.point;
            }
        }
        

    }
}
