using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Cube;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var ray = camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Cube.transform.position = hit.point;

            if(Input.GetMouseButtonDown(0))
            {
                Instantiate<GameObject>(Cube);
            }
            if (Input.GetMouseButtonDown(1) && hit.collider.gameObject == Cube.gameObject)
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
