using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCycle : MonoBehaviour
{
    public Material[] Errors = new Material[3];
    public int waitTime = 5;

    void Start()
    {
        StartCoroutine(ChangeMaterial());
    }

    IEnumerator ChangeMaterial ()
    {
        while (true)
        {
            for (int i = 0; i < Errors.Length; i++)
            {
                yield return new WaitForSeconds(waitTime);
                GetComponent<MeshRenderer>().material = Errors[i];
                yield return null;
            }
        }
    }
}
