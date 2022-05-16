using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    
    public GameObject FinalUI;
    public GameObject Bowl;
    public Transform fireSpawnPointLeft;
    public Transform fireSpawnPointRight;    
    
    private Animator playerAnimator;

    private KeyCode lastHitKey;

    private bool isthrown = false;

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
                    playerAnimator.SetBool("Feed",true);
                    // add courantine line
                    // yield return (new WaitForSeconds(1.5f));
                    GameObject bullet = Instantiate(Bowl,fireSpawnPointLeft.position,Quaternion.identity);  
                    bullet.GetComponent<Rigidbody>().velocity = transform.forward * 20;
                    isthrown = true;
                }
                else if(lastHitKey == KeyCode.D){
                    playerAnimator.SetBool("Feed",true);
                    // add courantine line
                    // yield return (new WaitForSeconds(1.5f));
                    GameObject bullet = Instantiate(Bowl,fireSpawnPointRight.position,Quaternion.identity);  
                    bullet.GetComponent<Rigidbody>().velocity = transform.forward * 20;
                    isthrown = true;
                }
                
                
            
        }

        if(Input.GetMouseButtonUp(0)){
            playerAnimator.SetBool("Feed",false);
            StartCoroutine((happy()));
        }
   }

   public IEnumerator happy(){
            playerAnimator.SetBool("Happy Jump",true);
            yield return (new WaitForSeconds(1.5f));
            playerAnimator.SetBool("Happy Jump",false);
            FinalUI.SetActive(true);
            

   }
}
