using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform maincam;
    Transform unit;
    Transform worldSpaceCanvas;

    public Vector3 offset;
    void Start()
    {
        maincam = Camera.main.transform;
        unit = transform.parent;
        worldSpaceCanvas = GameObject.FindObjectOfType<Canvas>().transform;
        transform.SetParent(worldSpaceCanvas);
    }

   
    void Update()
    {
        //transform.rotation = Quaternion.LookRotation(transform.position - maincam.transform.position);
        //transform.position = unit.position + offset;
    }
}
