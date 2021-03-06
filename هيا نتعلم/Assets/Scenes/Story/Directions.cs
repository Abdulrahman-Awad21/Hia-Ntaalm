using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Directions : MonoBehaviour
{

    [SerializeField]
    private GameObject previos, next,play,pause;
    
    private GameObject[] pages = new GameObject[36];
    private int currentPage = 0;
    

    void Start(){
        for (int i = 1; i <= 36; i++){
            pages[i-1] = GameObject.Find("p" + i);
        }

        for (int i = 0; i < 36; i++){
            pages[i].SetActive(false);
        }
        previos.SetActive(false);
        next.SetActive(false);
        play.SetActive(false);
        pause.SetActive(false);
    }

    public void home() 
    {
        SceneManager.LoadScene("Main Menu Scene");
    }

    public void backMenu() {
        SceneManager.LoadScene("Story Game");
    }

    public void startStory(int c)
    {
        next.SetActive(true);
        GameObject.Find("FingerTip").SetActive(false);
        GameObject.Find("GoldenAxe").SetActive(false);
        GameObject.Find("RabbitTirtle").SetActive(false);
        GameObject.Find("ThreePigs").SetActive(false);
        GameObject.Find("backGround").SetActive(false);

        currentPage = c;
        pages[currentPage].SetActive(true);
    }
    
    public void setFTStory()
    {
        startStory(0);
    }
    
    public void setGAStory()
    {
        startStory(1);
    }
   
    public void setRTStory()
    {
        startStory(2);
    }
    
    public void setTPStory()
    {
        startStory(3);
    }

    public void nextActive(){
        previos.SetActive(true);
        play.SetActive(true);
        pause.SetActive(true);
        if (currentPage < 32)
        {
            pages[currentPage].SetActive(false);
            pages[currentPage + 4].SetActive(true);
            currentPage += 4;
        }
        if(currentPage>27)
            next.SetActive(false);
    }
    
    public void previousActive(){
        next.SetActive(true);
        if (currentPage == 7 || currentPage == 6 || currentPage == 5 || currentPage == 4)
        { 
            previos.SetActive(false);
            play.SetActive(true);
            pause.SetActive(true);
        }
        if (currentPage > 3 )
        {
            pages[currentPage - 4].SetActive(true);
            pages[currentPage].SetActive(false);
            currentPage -= 4;
        }
        
    }

    public void playAudio()
    {
        pages[currentPage].GetComponent<AudioSource>().Play();
    }
    public void pauseAudio()
    {
        pages[currentPage].GetComponent<AudioSource>().Pause();
    }
}
