using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Navigtion : MonoBehaviour{

  private GameObject [] gO = new GameObject[26];
  private static int x;
  private GameObject []nav = new GameObject[2];
  


  // void Start(){

      
   
  // }
  
  public void startButton(){
      x=0;
      nav[0] = GameObject.Find("Next");
      nav[1] = GameObject.Find("Previous");
      nav[1].SetActive(false);

      for (int i = 1; i <= 26; i++){ 
        gO[i-1] = GameObject.Find("Letter ("+i+")");
      }

      for (int i = 1; i<26 ; i++){
        
        gO[i].SetActive(false);
      }

  }

  public void reloadScene(){
    SceneManager.LoadScene("En Alphabets");
  }
  public void mainMenu(){
    SceneManager.LoadScene("Main Menu Scene");
  }
  public void nextActive(){
    x++;
    Debug.Log(x+"");
    
    if (x == 0){
      nav[1].SetActive(false);
      nav[0].SetActive(true);
    }
    else if (x == 25){
      nav[0].SetActive(false);
    }
    else{
      nav[1].SetActive(true);
      nav[0].SetActive(true);
    }
    
    if (x>0 && x<=26){
      gO[x-1].SetActive(false);
      gO[x].SetActive(true);
      
    }
    else{}

    
  }
  public void previousActive(){
    x--;
    Debug.Log(x+"");
    if (x == 0){
      nav[1].SetActive(false);
    }
    else {
      nav[0].SetActive(true);
      nav[1].SetActive(true);
    }
    if(x>=0){
      gO[x].SetActive(true);
      gO[x+1].SetActive(false);
      
    }
    else{}
  }
}
