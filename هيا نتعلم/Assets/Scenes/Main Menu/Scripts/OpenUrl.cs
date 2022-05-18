using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    private GameObject github;
    public void Open()
    {
        github = GameObject.Find("Github").GetComponent<GameObject>();
        Application.OpenURL("https://github.com/Abdulrahman-Awad21/Hia-Ntaalm");
    }
}
