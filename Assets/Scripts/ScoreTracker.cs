using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public static int Score = 0;
    public bool isLeveled = false;

    private void Update()
    {
        if (isLeveled)
        {
            Score = GetComponent<Counter>().Score;
        }
    }
}
