using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RappishThrowTrigger : MonoBehaviour
{
    private Animator playerAnimator;
    [SerializeField] private Animator myAnimationContoller;

    public bool basket,ground;
    public AudioSource source;
    public AudioClip YayAudio;

    public GameObject LoseUI;
    
    
    private void  OnTriggerEnter(Collider other)
    {
        if (basket){
            if (other.CompareTag("Rubbish") ){
                
                Debug.Log("Yaaaaaaaaaay");
                source.PlayOneShot(YayAudio);
                StartCoroutine( happy(other));
                // Destroy(other.gameObject);
                
            }
        }
        else if (ground){
            
             if (other.CompareTag("Rubbish") ){
                
                LoseUI.SetActive(true);
                }
                

        }
    }

    private IEnumerator happy(Collider co){
                myAnimationContoller.SetBool("Happy Jump",true);
                yield return (new WaitForSeconds(1.5f));
                Destroy(co.gameObject);
                myAnimationContoller.SetBool("Happy Jump",false);
                // myAnimationContoller.SetBool("Walk With Rubbish",false);
                // myAnimationContoller.SetBool("Walking Left",true);
    }
}
