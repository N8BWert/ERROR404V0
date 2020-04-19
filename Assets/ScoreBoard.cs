using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    public static List<string> Names = new List<string>()
    {
        "AAA",
        "BBB",
        "CCC",
        "DDD",
        "EEE",
        "FFF",
        "GGG",
        "HHH",
        "III",
        "JJJ"
    };
    public static List<int> Scores = new List<int>()
    {
        270,
        240,
        210,
        180,
        150,
        120,
        90,
        60,
        30,
        0
    };
    private List<string> Alphabet = new List<string>()
    {
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
    };
    public Text Board;
    public Text UserScore;
    private bool OnBoard = false;
    private string FirstChoiceString;
    private string SecondChoiceString;
    private string ThirdChoiceString;
    private string FullChoice; 
    int IndexofFirst;
    int IndexofSecond;
    int IndexofThird;
    int SideWaysIndex = 1;
    bool hasChosen;
    private string BoardText;
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        FirstChoiceString = Alphabet[0];
        SecondChoiceString = Alphabet[0];
        ThirdChoiceString = Alphabet[0];
        FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
        UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
        BoardEditor();
    }
    private void Update()
    {
        NameUpdate();
        ScoreUpdate();
    }
    void BoardEditor ()
    {
        for (int j = 0; j < 10; j++)
        {
            BoardText = BoardText + (j + 1) + ". " + Names[j] + " --- " + Scores[j] + "\n";
        }
        Board.text = BoardText;
    }
    void ScoreUpdate ()
    {
        if (!OnBoard && hasChosen)
        {
            for (int i = 0; i < Scores.Count; i++)
            {
                if (ScoreTracker.Score > Scores[i])
                {
                    if(OnBoard)
                    {
                        continue;
                    }
                    Scores.Insert(i, ScoreTracker.Score);
                    Names.Insert(i, FullChoice);
                    OnBoard = true;
                    Debug.Log("On The Board");
                    continue;
                }
            }
        }
        if(OnBoard)
        {
            Debug.Log("We're here");
            BoardText = "";
            for (int j = 0; j < 10; j++)
            {
                BoardText = BoardText + (j + 1) + ". " + Names[j] + " --- " + Scores[j] + "\n";
            }
            Board.text = BoardText;
            Invoke("NextScene", 2);
        }
    }
    void NextScene()
    {
        if(OnBoard)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
    void NameUpdate ()
    {
        if(!hasChosen)
        {
            if (SideWaysIndex == 1)
            {
                if(Input.GetKeyDown(KeyCode.W))
                {
                    IndexofFirst += 1;
                    if (IndexofFirst > 26)
                    {
                        IndexofFirst = 0;
                    }
                    FirstChoiceString = Alphabet[IndexofFirst];
                    FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
                    UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    IndexofFirst -= 1;
                    if (IndexofFirst < 0)
                    {
                        IndexofFirst = 26;
                    }
                    FirstChoiceString = Alphabet[IndexofFirst];
                    FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
                    UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    SideWaysIndex = 2;
                }
            }
            else if (SideWaysIndex == 2)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    IndexofSecond += 1;
                    if (IndexofSecond > 26)
                    {
                        IndexofSecond = 0;
                    }
                    SecondChoiceString = Alphabet[IndexofSecond];
                    FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
                    UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    IndexofSecond -= 1;
                    if (IndexofSecond < 0)
                    {
                        IndexofSecond = 26;
                    }
                    SecondChoiceString = Alphabet[IndexofSecond];
                    FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
                    UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    SideWaysIndex = 3;
                }
            }
            else if (SideWaysIndex == 3)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    IndexofThird += 1;
                    if (IndexofThird > 26)
                    {
                        IndexofThird = 0;
                    }
                    ThirdChoiceString = Alphabet[IndexofThird];
                    FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
                    UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    IndexofThird -= 1;
                    if (IndexofThird < 0)
                    {
                        IndexofThird = 26;
                    }
                    ThirdChoiceString = Alphabet[IndexofThird];
                    FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
                    UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    SideWaysIndex = 4;
                    hasChosen = true;
                }
            }
        }
        
        /*while(!FirstChoiceBool)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                IndexofFirst += 1;
                if(IndexofFirst > 26)
                {
                    IndexofFirst = 0;
                }
                FirstChoiceString = Alphabet[IndexofFirst];
                FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
                UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
            }
            if(Input.GetKeyDown(KeyCode.S))
            {
                IndexofFirst -= 1;
                if(IndexofFirst < 0)
                {
                    IndexofFirst = 26;
                }
                FirstChoiceString = Alphabet[IndexofFirst];
                FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
                UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
            }
            if(Input.GetButtonDown("Fire1"))
            {
                FirstChoiceBool = true;
            }
        }
        while(!SecondChoiceBool)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                IndexofSecond += 1;
                if (IndexofSecond > 26)
                {
                    IndexofSecond = 0;
                }
                FirstChoiceString = Alphabet[IndexofSecond];
                FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
                UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                IndexofSecond -= 1;
                if (IndexofSecond < 0)
                {
                    IndexofSecond = 26;
                }
                FirstChoiceString = Alphabet[IndexofSecond];
                FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
                UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                SecondChoiceBool = true;
            }
        }
        while(!ThirdChoiceBool)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                IndexofThird += 1;
                if (IndexofThird > 26)
                {
                    IndexofThird = 0;
                }
                FirstChoiceString = Alphabet[IndexofThird];
                FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
                UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                IndexofThird -= 1;
                if (IndexofThird < 0)
                {
                    IndexofThird = 26;
                }
                FirstChoiceString = Alphabet[IndexofThird];
                FullChoice = FirstChoiceString + SecondChoiceString + ThirdChoiceString;
                UserScore.text = FullChoice + " --- " + ScoreTracker.Score;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                ThirdChoiceBool = true;
            }
        }*/
    }
}
