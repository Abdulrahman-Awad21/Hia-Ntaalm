using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looping : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;

    private  float horizintalValue;
    // Update is called once per frame
    void Update()
    {
        horizintalValue = Input.GetAxis("Horizontal");
        move();    
    }
    void move(){
        if (horizintalValue >0)
            backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime,0f);
        else if (horizintalValue <0)
            backgroundRenderer.material.mainTextureOffset += new Vector2(- backgroundSpeed * Time.deltaTime,0f);
        else{ 
            backgroundRenderer.material.mainTextureOffset += new Vector2( 0 * Time.deltaTime,0f);
            }
    }
}
