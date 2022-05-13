using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed ;
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
            playerAnimator.SetBool("Walking Left" , true);
            GetComponent<SpriteRenderer>().flipX = true;
            }
        else if (horizintalValue <0){
            playerAnimator.SetBool("Walking Left" , true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        { 
            playerAnimator.SetBool("Walking Right" , false);
            playerAnimator.SetBool("Walking Left" , false);
            }
    }
    

}
