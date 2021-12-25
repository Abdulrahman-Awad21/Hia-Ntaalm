using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Speech : MonoBehaviour, IPointerEnterHandler
{
    int counter = 0;

    //public void OnMouseDown()
    //{
    //    string text = GetComponentInChildren<Text>().text;
    //    string url1 = "https://eng.kumandang.com/tts.php?text=" + text;
    //    string url2 = "https://translate.google.com.eg/?hl=ar&sl=en&tl=en&text="+text+"&op=translate";
    //    StartCoroutine(DownloadAndPlay(url1));
    //}

    [System.Obsolete]
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        string name = GetComponentInParent<Button>().GetComponentInChildren<Text>().text;
        //Debug.Log(name);
        //string text = GetComponentInChildren<Text>().text;
        string url1 = "https://eng.kumandang.com/tts.php?text=" + name;
        //string url2 = "https://translate.google.com.eg/?hl=ar&sl=en&tl=en&text="+text+"&op=translate";
        StartCoroutine(DownloadAndPlay(url1));
    }

    [System.Obsolete]
    IEnumerator DownloadAndPlay(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        GameObject gameObject = GameObject.FindGameObjectWithTag("speech");
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.clip = www.GetAudioClip(false, false, AudioType.UNKNOWN);
        audio.Play();
    }
}
