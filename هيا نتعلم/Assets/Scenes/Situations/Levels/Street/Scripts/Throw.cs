using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject rubbish;
    public Transform fireSpawnPoint;
    public float fireRate = 0.5f;
    
    private Animator playerAnimator;

    private bool isthrown = false;

    private void Awake() {
        playerAnimator = GetComponentInChildren<Animator>();
    }
   private void Update() {
        if(Input.GetMouseButton(0) && !isthrown){
            
            playerAnimator.SetBool("Throw",true);
            // add courantine line
            // yield return (new WaitForSeconds(1.5f));
            GameObject bullet = Instantiate(rubbish,fireSpawnPoint.position,Quaternion.identity);  
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 20;
            isthrown = true;
        }
        if(Input.GetMouseButtonUp(0)){
            playerAnimator.SetBool("Throw",false);
        }
   }

}
