using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RappishThrowTrigger : MonoBehaviour
{
    private Animator playerAnimator;
    [SerializeField] private Animator myAnimationContoller;

    public bool basket,ground;
    
    public GameObject Sound;
    private IEnumerator  OnTriggerEnter(Collider other)
    {
        if (basket){
            if (other.CompareTag("Rubbish") ){
                
                Debug.Log("Yaaaaaaaaaay");
                myAnimationContoller.SetBool("Happy Jump",true);
                yield return (new WaitForSeconds(1.5f));
                myAnimationContoller.SetBool("Happy Jump",false);
                Destroy(other.gameObject);
                
            }
        }
        else if (ground){

             if (other.CompareTag("Rubbish") ){
                SceneManager.LoadScene("ThrowRubbish");   
                Debug.Log("BadBoy");
                }
                

        }
    }
}
