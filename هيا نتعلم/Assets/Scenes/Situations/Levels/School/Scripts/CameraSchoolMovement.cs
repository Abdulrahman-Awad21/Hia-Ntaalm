using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSchoolMovement : MonoBehaviour
{
    public Transform followTransform;

    public Vector2 offset;

    
    void Update()
    {
        this.transform.position = new Vector3(followTransform.position.x + offset.x, followTransform.position.y + +offset.y, this.transform.position.z);


    }
}
