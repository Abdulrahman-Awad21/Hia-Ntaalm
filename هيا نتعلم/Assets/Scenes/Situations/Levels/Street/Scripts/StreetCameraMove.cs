using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetCameraMove : MonoBehaviour
{
   public Transform followTransform;

    public Vector2 offset;

    public float y = -0.86f;

    
    void Update()
    {
        this.transform.position = new Vector3(followTransform.position.x + offset.x, y ,this.transform.position.z);


    }
}
