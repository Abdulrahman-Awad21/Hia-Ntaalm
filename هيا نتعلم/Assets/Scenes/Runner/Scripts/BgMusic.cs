using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    private static BgMusic backgroundMusic;
   
   void Awake(){

       if(backgroundMusic == null){
           backgroundMusic = this;
           DontDestroyOnLoad(backgroundMusic);
       }
       else{
           Destroy(gameObject);
       }

   }
}
