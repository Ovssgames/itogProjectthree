using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressPrefabRighetBody : MonoBehaviour
{
    public float delay = 5;

    private Rigidbody _rigidbody;
    private Collider _collider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();
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
}  



