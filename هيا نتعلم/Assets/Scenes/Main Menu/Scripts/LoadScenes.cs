using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void playArAlphabet (){
        SceneManager.LoadScene(1);
    }
    public void playColors (){
        SceneManager.LoadScene(2);
    }
    public void playThings (){
        SceneManager.LoadScene(3);
    }
    public void playEnAlphabets (){
        SceneManager.LoadScene(4);
    }
    public void playNumbers (){
        SceneManager.LoadScene(5);
    }
     public void playStory (){
        SceneManager.LoadScene(6);
    }

    
}
