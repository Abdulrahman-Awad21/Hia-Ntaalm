using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTriger : MonoBehaviour
{
    
    private Animator playerAnimator;
    [SerializeField] private Animator myAnimationContoller;

    // Start is called before the first frame update

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )    {
            
            myAnimationContoller.SetBool("Happy Jump",true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") )    {
            myAnimationContoller.SetBool("Happy Jump",false);
        }
    }
}
