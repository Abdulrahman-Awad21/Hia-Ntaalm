using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSchoolMovement : MonoBehaviour
{
    public Transform followTransform;

    public Vector2 offset;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            SceneManager.LoadScene("Main Menu Scene");
            return;
        }
        this.transform.position = new Vector3(followTransform.position.x + offset.x, followTransform.position.y + +offset.y, this.transform.position.z);


    }
}
