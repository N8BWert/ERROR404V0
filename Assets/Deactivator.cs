using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Deavtivate());
    }
    IEnumerator Deavtivate()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
