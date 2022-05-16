using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject rubbish;
    public Transform fireSpawnPointLeft;
    public Transform fireSpawnPointRight;    
    
    private Animator playerAnimator;

    private KeyCode lastHitKey;

    private bool isthrown = false;


    public bool isThrown(){
        return isthrown;
    }
    private void Awake() {
        playerAnimator = GetComponentInChildren<Animator>();
    }
   private void Update() {
        if (Input.GetKeyDown(KeyCode.D)){
           lastHitKey = KeyCode.D;
        }
        else if (Input.GetKeyDown(KeyCode.A)){
            lastHitKey = KeyCode.A;
        }

        if(Input.GetMouseButton(0) && !isthrown){

                if(lastHitKey == KeyCode.A){
                    playerAnimator.SetBool("Throw",true);
                    // add courantine line
                    // yield return (new WaitForSeconds(1.5f));
                    GameObject bullet = Instantiate(rubbish,fireSpawnPointLeft.position,Quaternion.identity);  
                    bullet.GetComponent<Rigidbody>().velocity = transform.forward * 20;
                    isthrown = true;
                }
                else if(lastHitKey == KeyCode.D){
                    playerAnimator.SetBool("Throw",true);
                    // add courantine line
                    // yield return (new WaitForSeconds(1.5f));
                    GameObject bullet = Instantiate(rubbish,fireSpawnPointRight.position,Quaternion.identity);  
                    bullet.GetComponent<Rigidbody>().velocity = transform.forward * 20;
                    isthrown = true;
                }
                
                
            
        }

        if(Input.GetMouseButtonUp(0)){
            playerAnimator.SetBool("Throw",false);
        }
   }

}
