using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    int Num;
    public Transform enemySpawn;
    public int waitTime = 5;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            Num = Random.Range(0, Enemies.Count);
            Instantiate(Enemies[Num], enemySpawn.position, enemySpawn.rotation);
            yield return new WaitForSeconds(waitTime);
            yield return null;
        }
    }
}
