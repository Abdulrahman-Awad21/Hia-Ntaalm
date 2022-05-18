using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public struct Player
{
    static int generator = 0;

    public int id;
    public string playerName;
    public int playerScore;
    public int playerRightAnswers;
    public int playerWrongAnswers;

    public Player(string _name = "")
    {
        id = generator++;
        playerName = _name;
        playerScore = 0;
        playerRightAnswers = 0;
        playerWrongAnswers = 0;
    }

    public Player(Player p)
    {
        id = p.id;
        playerName = p.playerName;
        playerScore = p.playerScore;
        playerRightAnswers = p.playerRightAnswers;
        playerWrongAnswers = p.playerWrongAnswers;
    }

    public void increaseScore()
    { 
        playerScore++;
        playerRightAnswers++;
    }

    public void decreaseScore()
    {
        playerScore--;
        playerWrongAnswers++;
    }
}

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
    private List<Question> questions = new List<Question>(); // questions without right answerd questions, when empty them he answered all questions
    private List<Question> AllQuestions = new List<Question>(); // always store all questions for taking random wrong answers
    private FullQuestion fullQuestion = new FullQuestion();   // structure contains image, right answer, and two wrong answers
    Button rightButton;
    GameObject go = null;
    private string mainDirectory = "Assets/Scenes/Guess The Feelings/Assets/Resources/Images";
    public AudioClip right, wrong;
    AudioSource audioSource;

    private playerControl playerControl = new playerControl();
    private List<Player> players = new List<Player>();
    int currentPlayer = -1;


    GameObject pickPlayers;
    GameObject mainCanvas;
    void Start()
    {
        pickPlayers = GameObject.FindGameObjectWithTag("pickPlayersPanel");
        mainCanvas = GameObject.FindGameObjectWithTag("mainCanvas");
        go = GameObject.Find("Github");
        Debug.Log(go);
        playerControl.start();
    }

    public void startGame()
    {
        players = playerControl.addPlayers();
        pickPlayers.SetActive(false);
        mainCanvas.SetActive(true);
        playerControl.displayPlayers(players);
        go = GameObject.Find("Github").GetComponent<GameObject>();
        loadFiles();
        //getImages();
        AllQuestions = new List<Question>(questions);
        //fullQuestion = newQuestion();
        fullQuestion = newDifferentQuestion();
        assignValues(fullQuestion);

        GameObject audio = GameObject.FindGameObjectWithTag("answerMusic");
        audioSource = audio.GetComponent<AudioSource>();
    }

    public void assignValues(FullQuestion fullQuestion)
    {
        currentPlayer = (currentPlayer + 1) % players.Count;
        playerControl.displayCurrentPlayerInfo(players[currentPlayer]);
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
        btn.onClick.AddListener(() => wrongAnswer());

        // assign button2
        rand = Random.Range(0, 2);
        index = temp[rand];// select random index from temp
        temp.RemoveAt(rand);// remove selected index
        btn = buttons[index].GetComponent<Button>();
        btn.GetComponentInChildren<Text>().text = fullQuestion.wrongAnswer2; // this button is assigned to wrong answer
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() => wrongAnswer());

        // assign button3
        index = temp[0];
        btn = buttons[index].GetComponent<Button>();
        btn.GetComponentInChildren<Text>().text = fullQuestion.question._name; // this button is always true
        rightButton = btn; // save it for later usage/comparison for checking answer 
        btn.onClick.RemoveAllListeners();   
        btn.onClick.AddListener(() => rightAnswer());
    }

    void rightAnswer()
    {
        audioSource.Stop();
        audioSource.clip = right;
        audioSource.Play();

        Player player = new Player(players[currentPlayer]);
        player.increaseScore();
        players[currentPlayer] = player;
        playerControl.updatePlayerScore(players[currentPlayer]);
        playerControl.displayCurrentPlayerInfo(players[currentPlayer]);
        
        questions.Remove(fullQuestion.question);
        fullQuestion = newDifferentQuestion();
        assignValues(fullQuestion);

        
    }

    void wrongAnswer()
    {
        audioSource.Stop();
        audioSource.clip = wrong;
        audioSource.Play();


        Player player = new Player(players[currentPlayer]);
        player.decreaseScore();
        players[currentPlayer] = player;
        playerControl.updatePlayerScore(players[currentPlayer]);
        playerControl.displayCurrentPlayerInfo(players[currentPlayer]);
        
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
    List<Question> getAllOfDifferentType(Question q)
    {
        List<Question> result = new List<Question>();

        for (int i = 0; i < AllQuestions.Count; i++)
        {
            if (AllQuestions[i]._type != q._type)
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

            Question question = getRandome(temp); // select random question

            temp = getAllOfType(question);

            temp.Remove(question); // remove selected question, and select 2 arbitrary questions

            Question wrongAnswer1 = getRandome(temp);
            temp.Remove(wrongAnswer1);

            Question wrongAnswer2 = getRandome(temp);

            fquestion.question = question;
            fquestion.wrongAnswer1 = wrongAnswer1._name;
            fquestion.wrongAnswer2 = wrongAnswer2._name;

        }
        else if (questions.Count == 1)
        {
            loadFiles();
        }
        return fquestion;
    }

    List<string> allTypes = new List<string>();

    public FullQuestion newDifferentQuestion()
    {
        List<string> types = new List<string>(allTypes);

        FullQuestion fquestion = new FullQuestion(); // question with right, and two wrong answers
        if (questions.Count >= 2)
        {
            List<Question> temp = new List<Question>(questions);

            Question question = getRandome(temp); // select random question
            types.Remove(question._type);

            string type1 = types[0];
            string type2 = types[1];

            //Question wrongAnswer1 = getRandome(temp, types);
            //types.Remove(wrongAnswer1._type);


            //Question wrongAnswer2 = getRandome(temp, types);

            //Debug.Log("-->" + " " + question._type + " - " + type1);
            fquestion.question = question;
            fquestion.wrongAnswer1 = type1;
            fquestion.wrongAnswer2 = type2;
            
        }
        else
        {
            Debug.Log("No more!");
            //getImages();
            loadFiles();
        }
        return fquestion;
    }

    Question getRandome(List<Question> temp)
    {
        //Debug.Log(temp.Count);
        int rand = Random.Range(0, temp.Count);
        Question ques = new Question(temp[rand]._name, temp[rand]._srcImg, temp[rand]._type);

        return ques;
    }

    Question getRandome(List<Question> temp, List<string> types)
    {
        //Debug.Log(types.Count);
        int rand = Random.Range(0, temp.Count);
        Question ques = new Question(temp[rand]._name, temp[rand]._srcImg, temp[rand]._type);
        foreach(Question q in temp)
        {
            bool different = false;
            foreach(string type in types)
            {
                if (q._type != type)
                {
                    different = false;
                }
                else
                {
                    different = true;
                }
                if (different == true)
                    return q;

            }

        }
        //Debug.Log("asdasdas="+rand);
        return ques;
    }

    public void loadFiles()
    {
        string[] folders = Directory.GetDirectories(mainDirectory);
        foreach (string subFolder in folders)
        {
            string[] subSubFolders = Directory.GetDirectories(subFolder);
            if (subSubFolders.Length > 0)
            {
                foreach (string subSubFolder in subSubFolders)
                {
                    //Debug.Log(subSubFolder);
                    string[] sourceImages = Directory.GetFiles(subSubFolder, "*.jpg");
          
                    string type = Path.GetFileName(subSubFolder);

                    allTypes.Add(type);

                    foreach (string sourceImage in sourceImages)
                    {
                        string srcImg = sourceImage;
                        
                        srcImg = srcImg.Replace(".jpg", "");
                        srcImg = srcImg.Replace(mainDirectory, "Images");
                        string name = Path.GetFileName(subSubFolder);
                        Debug.Log(name + " " + srcImg + " " + type);
                        Question question = new Question(name, srcImg, type);
                        questions.Add(question);
                    }

                }
            }
            else
            {
                string[] sourceImages = Directory.GetFiles(subFolder, "*.jpg");
                string type = Path.GetFileName(subFolder);
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

                Debug.Log(srcImg);

                string name = Path.GetFileNameWithoutExtension(srcImg);

                Question question = new Question(name, srcImg, type);
                questions.Add(question);
            }
        }
    }
}