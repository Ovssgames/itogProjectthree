﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public Transform tragetPoint;
    public Camera cameraLink;
    public float targetInSkyDistanse;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            tragetPoint.position = hit.point;
        }
        else
        {
            tragetPoint.position = ray.GetPoint(targetInSkyDistanse);
        }

        transform.LookAt(tragetPoint.position);
    }
}
