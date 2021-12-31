using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigtion : MonoBehaviour{

  private GameObject [] gO = new GameObject[26];
  private static int x =0;
  


  void Start(){

      
      for (int i = 1; i <= 26; i++){ 
        gO[i-1] = GameObject.Find("Letter ("+i+")");
      }
      for (int i = 1; i<26 ; i++){
        
        gO[i].SetActive(false);
      }
      // string g = gO[0].name;
      //   Debug.Log(g);
   
  }
  public void nextActive(){
    if (x<25){
      gO[x].SetActive(false);
      gO[x+1].SetActive(true);
      x++;
    }
    else{}
  }
  public void previousActive(){
    if(x>0){
      gO[x-1].SetActive(true);
      gO[x].SetActive(false);
      x--;
    }
    else{}
  }
}
