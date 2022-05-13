using UnityEngine.SceneManagement;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
    public bool isRightAnswer;

    public AudioClip rightAnswerClip;  // MP3 fking file 
    public AudioClip wrongAnswerClip;

    public AudioSource audioSource; // audio source object, takes shit audio clip to be fuking played

    bool isAnswerChecked = false; // so that stupied script dont exit from the class until the smart handsome boy select answer

    public void check()
    {
        if (isRightAnswer)
        {
            audioSource.clip = rightAnswerClip;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = wrongAnswerClip;
            audioSource.Play();
        }
        isAnswerChecked = true;
    }
    private void Update()
    {
        if (!audioSource.isPlaying && isAnswerChecked)
        {
            SceneManager.LoadScene("School");
        }
    }
}
