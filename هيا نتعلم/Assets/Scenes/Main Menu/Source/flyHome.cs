using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyHome : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();    
        speed = 100;
    }

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed , 0);
        
    }
}
