using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed ;
    private Animator playerAnimator;
    private  float horizintalValue;

    private void Awake() {
        playerAnimator = GetComponentInChildren<Animator>();

    }
    
    // Update is called once per frame
    void Update()
    {
        horizintalValue = Input.GetAxis("Horizontal");
        move();
    }

    void move(){
        if (horizintalValue >0){
            playerAnimator.SetBool("Walking Right" , true);
            
            }
        else if (horizintalValue <0){
            playerAnimator.SetBool("Walking Left" , true);
            
            }
        else{ 
            playerAnimator.SetBool("Walking Right" , false);
            playerAnimator.SetBool("Walking Left" , false);
            }
    }
    

}
