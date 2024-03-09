using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCol : MonoBehaviour
{
    public Transform CameraAxis;
    public float wishDistance = 2;
    public float zoomPosition;
    public float speed;
    public bool isZoom;

    // Update is called once per frame
    void Update()
    {
        Collisionn();
        

    }

    private void Collisionn()
    {
        var ray = (transform.position - CameraAxis.position).normalized;

        RaycastHit hit;
        if (Physics.Raycast(CameraAxis.position, ray, out hit, wishDistance))
        {
            if (hit.collider != null && hit.collider.gameObject != gameObject)
            {
                transform.position = hit.point;
            }

        }
        else
        {
            transform.position = CameraAxis.position + ray * wishDistance;
        }

        if (Input.GetMouseButton(1))
        {
            wishDistance = Mathf.Lerp(wishDistance , zoomPosition , speed * Time.deltaTime);
            isZoom = true;
        }
        else
        {
            wishDistance = Mathf.Lerp(wishDistance , 2, speed * Time.deltaTime);
            isZoom = false;
        }
    }
}
