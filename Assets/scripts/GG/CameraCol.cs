using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCol : MonoBehaviour
{
    public Transform CameraAxis;
    public float wishDistance = 2;
    public float zoomPosition;
    public float speedAnimation;
    public float speed;
    public bool isZoom;
    public Animator animator;

    private PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

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
            wishDistance = Mathf.Lerp(wishDistance , zoomPosition , speedAnimation * Time.deltaTime);
            isZoom = true;
            animator.SetBool("isZoom", true);
            
        }
        else
        {
            wishDistance = Mathf.Lerp(wishDistance , 2, speedAnimation * Time.deltaTime);
            isZoom = false;
            animator.SetBool("isZoom", false);
            
        }
    }
}
