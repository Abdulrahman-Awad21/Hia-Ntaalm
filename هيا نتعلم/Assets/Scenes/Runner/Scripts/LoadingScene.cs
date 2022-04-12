using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteAfterTime());
    }
    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("SampleScene");
        // Code to execute after the delay
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
