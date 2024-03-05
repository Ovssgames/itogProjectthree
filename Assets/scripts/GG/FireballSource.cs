using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public Transform tragetPoint;
    public Camera cameraLink;
    public float targetInSkyDistanse;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject != player)
            {
                tragetPoint.position = hit.point;
            }
            else
            {
                tragetPoint.position = ray.GetPoint(targetInSkyDistanse);
            }
        }
        else
        {
            tragetPoint.position = ray.GetPoint(targetInSkyDistanse);
        }

        transform.LookAt(tragetPoint.position);
    }
}
