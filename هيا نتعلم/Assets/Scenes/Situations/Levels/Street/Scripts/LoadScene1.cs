using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour
{
    public void home()
    {
        SceneManager.LoadScene("Situations");
    }
    public void mainhome()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }
    public void playPark()
    {
        SceneManager.LoadScene("Park");
    }
    public void playThrow()
    {
        SceneManager.LoadScene("ThrowRubbish");
    }
    public void playTraffic()
    {
        SceneManager.LoadScene("Traffic Light");
    }

}
