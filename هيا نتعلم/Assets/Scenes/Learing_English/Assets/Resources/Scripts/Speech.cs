using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Speech : MonoBehaviour, IPointerEnterHandler
{
    [System.Obsolete]
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        string text = GetComponentInChildren<Text>().text;
        string url1 = "https://eng.kumandang.com/tts.php?text=" + text;
        string url2 = "https://translate.google.com.eg/?hl=ar&sl=en&tl=en&text="+text+"&op=translate";
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
