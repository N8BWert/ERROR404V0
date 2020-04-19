using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal2Placer : MonoBehaviour
{
    public GameObject Crystal;
    public int waitTime = 5;
    public GameObject DifMan;

    void Start()
    {
        StartCoroutine(Spawn());
    }
    void Update()
    {
        SpawnTimeCalculator();
    }
    void SpawnTimeCalculator()
    {
        waitTime = 16 - DifMan.GetComponent<Counter>().currentLevel;
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(Crystal, new Vector3(Random.Range(-75, 75), 0, Random.Range(-75, 55)), Quaternion.identity);
            yield return null;
        }
    }
}
