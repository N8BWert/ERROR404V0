using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text Clock;
    public Text Level;
    private int minutes;
    private int seconds;
    public int currentLevel;

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
    }
    void ClockUpdate()
    {
        minutes = Mathf.FloorToInt(Time.time / 60);
        seconds = Mathf.FloorToInt(Time.time % 60);
        Clock.text = minutes + ":" + seconds;
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
