using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICAdditions : MonoBehaviour
{
    GameObject Manager;

    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
        StartCoroutine(AddTime());
    }

    IEnumerator AddTime()
    {
        while (true)
        {
            Manager.GetComponent<CountDown>().ICTime();
            yield return new WaitForSeconds(5);
            yield return null;
        }
    }
}
