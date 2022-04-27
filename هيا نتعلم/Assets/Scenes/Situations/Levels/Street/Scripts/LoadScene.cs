using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public bool street = false ,icecream = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") ){

            if (street){
                SceneManager.LoadScene("ThrowRubbish");
                }
            else if (icecream){
                Debug.Log("Icecream");
                SceneManager.LoadScene("Traffic Light");
                }
        }
    }
}
