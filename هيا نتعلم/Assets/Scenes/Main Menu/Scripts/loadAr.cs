using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadAr : MonoBehaviour
{
    public void playArAlphabet (){
        SceneManager.LoadScene(1);
    }
    public void playNumbers (){
        SceneManager.LoadScene(2);
    }
    public void playColors (){
        SceneManager.LoadScene(3);
    }
    public void playThings (){
        SceneManager.LoadScene(4);
    }
    
}
