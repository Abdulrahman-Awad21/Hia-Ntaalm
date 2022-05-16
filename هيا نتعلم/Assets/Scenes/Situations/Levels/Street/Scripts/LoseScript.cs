using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{

    public GameObject LoseUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") ){
               LoseUI.SetActive(true);
            
        }
    }
}
