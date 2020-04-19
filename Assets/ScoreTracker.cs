using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static int Score = 0;

    private void Update()
    {
        Debug.Log(Score);
        Score = GetComponent<Counter>().Score;
    }
}
