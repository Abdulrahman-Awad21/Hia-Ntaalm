using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(){
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit(){
        SceneManager.LoadScene("Main Menu Scene");
        // load the original ui of the project
    }
}
