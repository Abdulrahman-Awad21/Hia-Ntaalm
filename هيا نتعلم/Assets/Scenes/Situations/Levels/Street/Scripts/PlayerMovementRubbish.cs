using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRubbish : MonoBehaviour
{
        public float speed ;

    private Rigidbody rb;

    private Animator playerAnimator;
    private  float horizintalValue;

    private Vector2 playerDirection;
    
    private Throw th;

    private void Awake() {
        playerAnimator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        
        th = FindObjectOfType<Throw>();

    }
    
    // Update is called once per frame
    void Update()
    {
        horizintalValue = Input.GetAxis("Horizontal");
        move();
    }

    void move(){
        if(!th.isThrown()){
            if (horizintalValue >0 ){
                playerAnimator.SetBool("Walk With Rubbish" , true);
                float directionX = Input.GetAxisRaw("Horizontal");
                playerDirection = new Vector2(directionX, 0).normalized;
                GetComponent<SpriteRenderer>().flipX = true;
                }
            else if (horizintalValue <0){
                playerAnimator.SetBool("Walk With Rubbish" , true);
                float directionX = Input.GetAxisRaw("Horizontal");
                playerDirection = new Vector2(directionX, 0).normalized;
                GetComponent<SpriteRenderer>().flipX = false;
                
                }
            else{ 
                playerAnimator.SetBool("Walk With Rubbish" , false);
                }
        }
        else if (th.isThrown()){
            playerAnimator.SetBool("Walk With Rubbish" , false);
            if (horizintalValue >0 ){
                playerAnimator.SetBool("Walking Left" , true);
                float directionX = Input.GetAxisRaw("Horizontal");
                playerDirection = new Vector2(directionX, 0).normalized;
                GetComponent<SpriteRenderer>().flipX = true;
                }
            else if (horizintalValue <0){
                playerAnimator.SetBool("Walking Left" , true);
                float directionX = Input.GetAxisRaw("Horizontal");
                playerDirection = new Vector2(directionX, 0).normalized;
                GetComponent<SpriteRenderer>().flipX = false;
                
                }
            else{ 
                playerAnimator.SetBool("Walking Left" , false);
                }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
     
    }

    

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * speed,0);
    }
    
}
