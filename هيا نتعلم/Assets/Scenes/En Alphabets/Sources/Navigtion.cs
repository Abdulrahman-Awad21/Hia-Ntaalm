using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigtion : MonoBehaviour
{
  
  private GameObject o;
  static int x= 1;
  public void nextObject(){
      Debug.Log("Button Pressed");
      o = GameObject.FindGameObjectWithTag("BT1");
      Debug.Log("Object mybe found ");
  }
}
