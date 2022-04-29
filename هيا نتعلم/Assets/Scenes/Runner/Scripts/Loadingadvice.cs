using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Loadingadvice : MonoBehaviour
{
    public Text txt;
    string[] adv = { "Get vaccinated as soon as it�s your turn and follow local guidance on vaccination."
            , "Keep physical distance of at least 1 metre from others, even if they don�t appear to be sick. Avoid crowds and close contact."
            , "Wear a properly fitted mask when physical distancing is not possible and in poorly ventilated settings."
            , "Clean your hands frequently with alcohol-based hand rub or soap and water.",
        "Cover your mouth and nose with a bent elbow or tissue when you cough or sneeze. Dispose of used tissues immediately and clean hands regularly. ",
    "If you develop symptoms or test positive for COVID-19, self-isolate until you recover."};
    void Awake()
    {
        int i = Random.Range(0,6);
        txt.text = adv[i];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
