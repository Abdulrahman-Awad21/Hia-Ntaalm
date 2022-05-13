using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSituations : MonoBehaviour
{
    public void playHome()
    {
        SceneManager.LoadScene("home");
    }
    public void playSchool()
    {
        SceneManager.LoadScene("School");
    }
    public void playStreet()
    {
        SceneManager.LoadScene("Traffic Light");
    }

}
