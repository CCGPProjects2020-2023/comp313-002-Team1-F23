using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//created and modified on 10/30 by Laura A
public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
