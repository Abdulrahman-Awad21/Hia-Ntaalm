using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public struct Question
{
    public string _name;
    public string _srcImg;
    public string _type;
    
    public Question(string name = "", string srcImg = "", string type = "")
    {
        _name = name;
        _srcImg = srcImg;
        _type = type;
    }
}

public struct FullQuestion
{
    public Question question;
    public string wrongAnswer1;
    public string wrongAnswer2;
}


public class Generator : MonoBehaviour
{
    private List<Question> questions    = new List<Question>(); // questions without right answerd questions, when empty them he answered all questions
    private List<Question> AllQuestions = new List<Question>(); // always store all questions for taking random wrong answers
    private FullQuestion   fullQuestion = new FullQuestion();   // structure contains image, right answer, and two wrong answers
    Button rightButton;

    private string mainDirectory = "Assets/Scenes/Learing_English/Assets/Resources/Images";

    public AudioClip right, wrong;
    AudioSource audioSource;

    void Start()
    {
        getImages();
        AllQuestions = new List<Question>(questions);
        fullQuestion = newQuestion();
        assignValues(fullQuestion);

        GameObject audio = GameObject.FindGameObjectWithTag("answerMusic");
        audioSource = audio.GetComponent<AudioSource>();
    }

    public bool isRight(Button btn)
    {
        if (rightButton == btn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void assignValues(FullQuestion fullQuestion)
    {
        // assign image
        GameObject image = GameObject.FindGameObjectWithTag("Gimage");
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
        Image img = image.GetComponent<Image>();
        img.sprite = Resources.Load<Sprite>(fullQuestion.question._srcImg); // extension shoudn't be written


        // select random value from temp, and assign it to button, produces random values for random buttons
        List<int> temp = new List<int> { 0, 1, 2 };

        // assign button1
        int rand = Random.Range(0, 3); // select random    **** from 0 and less than 3 ****
        int index = temp[rand]; // select random index from temp
        temp.RemoveAt(rand); // remove selected index
        Button btn = buttons[index].GetComponent<Button>();
        btn.GetComponentInChildren<Text>().text = fullQuestion.wrongAnswer1; // this button is assigned to wrong answer
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(wrongAnswer);

        // assign button2
        rand = Random.Range(0, 2);
        index = temp[rand];// select random index from temp
        temp.RemoveAt(rand);// remove selected index
        btn = buttons[index].GetComponent<Button>();
        btn.GetComponentInChildren<Text>().text = fullQuestion.wrongAnswer2; // this button is assigned to wrong answer
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(wrongAnswer);

        // assign button3
        index = temp[0];
        btn = buttons[index].GetComponent<Button>();
        btn.GetComponentInChildren<Text>().text = fullQuestion.question._name; // this button is always true
        rightButton = btn; // save it for later usage/comparison for checking answer 
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(rightAnswer);
    }

    void rightAnswer()
    {
        audioSource.Stop();
        audioSource.clip = right;
        audioSource.Play();


        Debug.Log("right");
        questions.Remove(fullQuestion.question);
        fullQuestion = newQuestion();
        assignValues(fullQuestion);
    }

    void wrongAnswer()
    {
        audioSource.Stop();
        audioSource.clip = wrong;
        audioSource.Play();

        Debug.Log("wrong");

    }

    void print(List<Question> temp)
    {
        for (int i = 0; i < temp.Count; i++)
        {
            Debug.Log(temp[i]._name);
        }
        Debug.Log("----------------");
    }

    List<Question> getAllOfType(Question q)
    {
        List<Question> result = new List<Question>();

        for (int i = 0; i < AllQuestions.Count; i++)
        {
            if (AllQuestions[i]._type == q._type)
                result.Add(AllQuestions[i]);
        }

        return result;
    }
    public FullQuestion newQuestion()
    {
        FullQuestion fquestion = new FullQuestion(); // question with right, and two wrong answers
        if (questions.Count != 0)
        {
            List<Question> temp = new List<Question>(questions);

            Question question = getRandome(temp); // select right answer

            temp = getAllOfType(question);
            
            temp.Remove(question); // remove the right answer, to select two different wrong answers

            Question wrongAnswer1 = getRandome(temp);
            temp.Remove(wrongAnswer1);
        
            Question wrongAnswer2 = getRandome(temp);

            fquestion.question = question;
            fquestion.wrongAnswer1 = wrongAnswer1._name;
            fquestion.wrongAnswer2 = wrongAnswer2._name;

        }
        else
        {
            Debug.Log("No more!");
            getImages();
        }
        return fquestion;
    }
    
    Question getRandome(List<Question> temp)
    {
        int rand = Random.Range(0, temp.Count);
        Question ques = temp[rand];

        return ques;
    }

    public void getImages()
    {
        // access image directory, for each directory get images info
        string[] subDirectories = Directory.GetDirectories(mainDirectory);

        foreach (string subDirectorie in subDirectories)
        {
            string[] sourceImages = Directory.GetFiles(subDirectorie, "*.jpg");
            
            string type = Path.GetFileName(subDirectorie);
            foreach (string sourceImage in sourceImages)
            {
                string srcImg = sourceImage;
                srcImg = srcImg.Replace(".jpg", "");
                srcImg = srcImg.Replace(mainDirectory, "Images");
                string name = Path.GetFileNameWithoutExtension(srcImg);
                
                Question question = new Question(name, srcImg, type);
                questions.Add(question);
            }
        }
    }
}
