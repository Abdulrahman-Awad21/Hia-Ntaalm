using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour
{
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
