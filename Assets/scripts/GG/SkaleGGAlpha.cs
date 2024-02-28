using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkaleGGAlpha : MonoBehaviour
{
    public Transform camera;

    public Material alpha;
    

    public float skroll;

    private Material _alpha;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, camera.position) < skroll)
        {
            alpha.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), 1 * Time.deltaTime);
        }
    }
}
