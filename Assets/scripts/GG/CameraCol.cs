using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCol : MonoBehaviour
{
    public Transform CameraAxis;
    public float wishDistance = 2;
    public float zoomPosition;
    public float speedAnimation;
    public float speedCameraIsDeath;
    public bool isZoom;
    public Animator animator;
    public Animator animatorGun;
    public GameObject aimImage;

    private PlayerHealth playerHealth;


    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
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

        if (Input.GetMouseButton(1) && playerHealth.value > 0)
        {
            wishDistance = Mathf.Lerp(wishDistance , zoomPosition , speedAnimation * Time.deltaTime);
            isZoom = true;
            animator.SetBool("isZoom", true);
            animatorGun.SetBool("isZoomGun", true);
            aimImage.SetActive(true);
            

        }
        else
        {
            if(playerHealth.value <= 0)
            {
                wishDistance = Mathf.Lerp(wishDistance, 6, speedCameraIsDeath * Time.deltaTime);
            }
            else
            {
                wishDistance = Mathf.Lerp(wishDistance, 2, speedAnimation * Time.deltaTime);
            }
            isZoom = false;
            animator.SetBool("isZoom", false);
            animatorGun.SetBool("isZoomGun", false);
            aimImage.SetActive(false);
        }
    }
}
