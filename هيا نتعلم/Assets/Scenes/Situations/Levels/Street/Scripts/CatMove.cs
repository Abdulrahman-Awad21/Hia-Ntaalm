using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    
   public float speed ;

    private Rigidbody rb;

    private Animator playerAnimator;
    

    private Vector2 playerDirection;

    private void Awake() {
        playerAnimator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();

    }
    
    
    private void Update() {
        move();
    }

    void move(){   
        
         
            playerDirection = new Vector2(1, 0).normalized;
         
            
            

    }    

    void FixedUpdate(){
        if(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            rb.velocity = new Vector2(playerDirection.x * speed,0);
        
        else 
            rb.velocity = new Vector2(playerDirection.x * 0,0);   
    }    
}
