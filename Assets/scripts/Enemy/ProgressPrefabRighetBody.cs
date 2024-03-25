using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressPrefabRighetBody : MonoBehaviour
{
    public float delay = 5;
    public float noActiveDistance;
    public GameObject TrigerProgress;

    private Rigidbody _rigidbody;
    private Collider _collider;
    private CameraCol CameraCol;
    private MeshRenderer MeshRenderer;
    private Light Light;
    private float r;

    private void Start()
    {
        Light = GetComponent<Light>();
        CameraCol = FindObjectOfType<CameraCol>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("isCollision", delay);
    }

    private void isCollision()
    {
        _rigidbody.isKinematic = true;
        _collider.isTrigger = true;
    }

    private void Update()
    {
        float dist = Vector3.Distance(CameraCol.transform.position, transform.position);
        if (dist > noActiveDistance)
        {
            MeshRenderer.enabled = false;
            TrigerProgress.SetActive(false);
            Light.enabled = false;
        }
        else
        {
            MeshRenderer.enabled = true;
            TrigerProgress.SetActive(true);
            Light.enabled = true;
        }
        r = dist;
    }
}  



