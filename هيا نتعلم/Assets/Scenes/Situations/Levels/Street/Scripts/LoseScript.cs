using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{

    public GameObject LoseUI;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") ){
               LoseUI.SetActive(true);
               Destroy(Player);
            
        }
    }
}
