using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
   public GameObject light1,light2;
   public float switchRate = 2f;
   private float nextLight;
   private bool gate = true;

   
   private void Update() {
       if (Time.time >=nextLight){
           
            nextLight = Time.time + switchRate;
            if(gate){
                light1.SetActive(true);
                light2.SetActive(false);
                gate = false;
            }
            else {
                light2.SetActive(true);
                light1.SetActive(false);
                gate = true;
            }
       }
   }
}

