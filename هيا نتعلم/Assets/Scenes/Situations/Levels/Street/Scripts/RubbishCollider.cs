using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishCollider : MonoBehaviour
{
    public string targetTag;
    public TargetToAct target;
    public enum TargetToAct{Ground}

    private Animator playerAnimator;
    [SerializeField] private Animator myAnimationContoller;
    private void OnCollisionEnter(Collision collision) {

        if(collision.gameObject.tag == targetTag){

            if(target == TargetToAct.Ground){

                myAnimationContoller.SetBool("Happy Jump",true);
            }

            else if (target == TargetToAct.Ground){
                // collision.gameObject.GetComponent<PlayerHealth>().decreaseHealth(5);
                // add Sad Act and repeat the scene
                Debug.Log("Bad Boy");
            }
        }

        Destroy(gameObject);
        
        
    }
}
