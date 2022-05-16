using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTriger : MonoBehaviour
{
    
    private Animator playerAnimator;
    [SerializeField] private Animator myAnimationContoller;

    public AudioSource source;
    public AudioClip YayAudio;


    
    private void  OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )    {
           StartCoroutine(happy());  
            
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") )    {
            myAnimationContoller.SetBool("Happy Jump",false);
        }
    }

    private IEnumerator happy(){
            myAnimationContoller.SetBool("Happy Jump",true);
            source.PlayOneShot(YayAudio);
            yield return (new WaitForSeconds(1.5f));
            myAnimationContoller.SetBool("Happy Jump",false);
    }
}
