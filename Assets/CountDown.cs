using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text Countdown;
    public float timeLeft;
    public float ogTime = 3600;
    private int minutes;
    private int seconds;
    public GameObject Furnace;

    void Start()
    {
        timeLeft = ogTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        minutes = Mathf.FloorToInt(timeLeft / 60);
        seconds = Mathf.FloorToInt(timeLeft % 60);
        Countdown.text = "Time: " + minutes + ":" + seconds;
    }
    public void AddTime()
    {
        timeLeft += 60 * Time.deltaTime;
        Furnace.GetComponent<Furnace>().PlayAnimation();
    }
}
