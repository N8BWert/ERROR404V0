using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    int Num;
    public Transform enemySpawn;

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
            yield return new WaitForSeconds(5);
            yield return null;
        }
    }
}
