using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void playArAlphabet (){
        SceneManager.LoadScene("Ar Alphabet");
    }
    public void playColors (){
        SceneManager.LoadScene("Color");
    }
    public void playThings (){
        SceneManager.LoadScene("SceneV2");
    }
    public void playEnAlphabets (){
        SceneManager.LoadScene("En Alphabets");
    }
    public void playNumbers (){
        SceneManager.LoadScene("Numbers Game");
    }
     public void playStory (){
        SceneManager.LoadScene("Story Game");
    }
    public void playRunner (){
        SceneManager.LoadScene("UI");
    }

    public void playSituations(){
        SceneManager.LoadScene("Situations");
    }
    public void closeApp()
    {
        Application.Quit();
    }
    
}
