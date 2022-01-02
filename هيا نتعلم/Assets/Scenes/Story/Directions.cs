using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Directions : MonoBehaviour
{

    private GameObject[] pages = new GameObject[36];
    private int currentPage = 0;

    void Start(){
        for (int i = 1; i <= 36; i++){
            pages[i-1] = GameObject.Find("p" + i);
        }
        
        for (int i = 0; i < 36; i++){
            pages[i].SetActive(false);
        }
    }

    public void backMenu() 
    {
        Start();
    }

    public void startStroy(int c)
    {
        GameObject.Find("FingerTip").SetActive(false);
        GameObject.Find("GoldenAxe").SetActive(false);
        GameObject.Find("RabbitTirtle").SetActive(false);
        GameObject.Find("ThreePigs").SetActive(false);
        GameObject.Find("backGround").SetActive(false);
        currentPage = c;
        pages[currentPage].SetActive(true);
    }
    
    public void setFTStory(){
        startStroy(0);
    }
    
    public void setGAStory()
    {
        startStroy(1);
    }
   
    public void setRTStory()
    {
        startStroy(2);
    }
    
    public void setTPStory()
    {
        startStroy(3);
    }

    public void nextActive(){
        if (currentPage + 4 < 36)
        {
            pages[currentPage].SetActive(false);
            pages[currentPage + 4].SetActive(true);
            currentPage += 4;
        }

        else { }
    }
    
    public void previousActive(){
        if (currentPage - 4 > 0)
        {
            pages[currentPage - 4].SetActive(true);
            pages[currentPage].SetActive(false);
            currentPage -= 4;
        }
        else { }
    }

}
