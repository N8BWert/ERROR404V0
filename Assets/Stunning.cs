using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunning : MonoBehaviour
{
    public float stunDistance = 6;
    public GameObject StunLocation;
    public float distanceEnemy;
    public bool isStunning = false;

    public void IsStunningTrue()
    {
        isStunning = true;
    }
    public void IsStunningFalse()
    {
        isStunning = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            distanceEnemy = Vector3.Distance(StunLocation.transform.position, other.gameObject.transform.position);
            if(distanceEnemy <= stunDistance && isStunning)
            {
                other.gameObject.GetComponent<AntiBacterialActions>().Stun();
            }
        }
    }
}
