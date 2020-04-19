using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text Clock;
    public Text Level;
    public Text ScoreText;
    public GameObject YourScoreIs;
    public GameObject ScoreBackground;
    public GameObject Instructions;
    private int minutes;
    private int seconds;
    public int currentLevel;
    public bool isWorking = true;
    public GameObject manager;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ClockUpdate();
        LevelCheck();
        Working();
    }
    void Working()
    {
        isWorking = manager.GetComponent<CountDown>().TheEnd;
        if(isWorking)
        {
            Score = minutes * 60 + seconds;
            ScoreText.text = "" + Score;
            YourScoreIs.SetActive(true);
            ScoreBackground.SetActive(true);
            Instructions.SetActive(true);
        }
    }
    void ClockUpdate()
    {
        if (!isWorking)
        {
            minutes = Mathf.FloorToInt(Time.time / 60);
            seconds = Mathf.FloorToInt(Time.time % 60);
            Clock.text = minutes + ":" + seconds;
        }
    }
    void LevelCheck()
    {
        if(Time.time / (60 *currentLevel) >= 1)
        {
            currentLevel++;
            Level.gameObject.SetActive(true);
            Level.text = "" + currentLevel;
        }
    }
}
