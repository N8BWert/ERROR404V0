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
    Animator anim;
    public bool TheEnd = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        timeLeft = ogTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        minutes = Mathf.FloorToInt(timeLeft / 60);
        seconds = Mathf.FloorToInt(timeLeft % 60);
        if(minutes <= 0 && seconds <= 0)
        {
            Countdown.text = "Time: 0:00";
        }
        else
        {
            Countdown.text = "Time: " + minutes + ":" + seconds;
        }
        Ending();
    }
    public void AddTime()
    {
        timeLeft += 60 * Time.deltaTime;
        Furnace.GetComponent<Furnace>().PlayAnimation();
    }
    public void LessTime()
    {
        timeLeft -= 20 * Time.deltaTime;
        anim.SetBool("isHurt", true);
    }
    public void ICTime()
    {
        timeLeft += 5;
    }
    public void Unhurt()
    {
        anim.SetBool("isHurt", false);
    }
    void Ending()
    {
        if(minutes <= 0 && seconds <= 0)
        {
            anim.SetBool("isDead", true);
            Invoke("SetTheEndTrue", 1.6f);
        }
    }
    void SetTheEndTrue()
    {
        TheEnd = true;
    }
}
