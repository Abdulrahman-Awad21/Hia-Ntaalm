using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Nav : MonoBehaviour{

  private GameObject [] gO = new GameObject[29];
  private static int x =0;
  


        public void home()
        {
            SceneManager.LoadScene("Main Menu Scene");
        }
  void Start(){



        for (int i = 0; i < 29; i++){ 
        gO[i] = GameObject.Find("p"+i);
      }
      for (int i = 1; i<29 ; i++){
        
        gO[i].SetActive(false);
      }
      // string g = gO[0].name;
      //   Debug.Log(g);
   
  }
  public void nextActive(){
    if (x<28){
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

    public void Restart()
    {
        x = 0;
        SceneManager.LoadScene("Ar Alphabet");
    }

}
