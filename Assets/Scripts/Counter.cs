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
    public GameObject Scoreobject;
    private int minutes;
    private int seconds;
    public int currentLevel;
    public bool isWorking = true;
    public GameObject manager;
    public int Score;
    public float timeOffset;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        Score = 0;
        timeOffset = Time.time;
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
            Scoreobject.SetActive(true);
            YourScoreIs.SetActive(true);
            ScoreBackground.SetActive(true);
            Instructions.SetActive(true);
        }
    }
    void ClockUpdate()
    {
        if (!isWorking)
        {
            minutes = Mathf.FloorToInt((Time.time - timeOffset) / 60);
            seconds = Mathf.FloorToInt((Time.time - timeOffset) % 60);
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
