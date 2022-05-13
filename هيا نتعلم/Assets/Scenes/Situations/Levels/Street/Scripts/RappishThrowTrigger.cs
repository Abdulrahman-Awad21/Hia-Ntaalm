using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RappishThrowTrigger : MonoBehaviour
{
    private Animator playerAnimator;
    [SerializeField] private Animator myAnimationContoller;
    private IEnumerator  OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rubbish") )    {
            
            myAnimationContoller.SetBool("Happy Jump",true);
            yield return (new WaitForSeconds(1.5f));
            myAnimationContoller.SetBool("Happy Jump",false);

            
        }
        else {

            Debug.Log("Bad Boy Animation");
        }
    }
}
