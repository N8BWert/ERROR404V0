using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    public GameObject manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("BRUH");
            other.gameObject.GetComponent<BacteriaDeath>().DIE();
            manager.GetComponent<CountDown>().AddTime();
        }
    }
}
