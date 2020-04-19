using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isPickingUp = false;
    public GameObject Pickeruper;
    public Transform pickUpLocation;
    public Transform groundLocation;

    public void PickItUp()
    {
        isPickingUp = true;
    }
    public void PutItDown()
    {
        isPickingUp = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if(other.gameObject.GetComponent<AntiBacterialActions>().currentStunTime > 0 && isPickingUp)
            {
                other.gameObject.transform.position = pickUpLocation.position;
                other.gameObject.transform.rotation = pickUpLocation.rotation;
                other.gameObject.transform.parent = Pickeruper.transform;
            }
            if(other.gameObject.GetComponent<AntiBacterialActions>().currentStunTime <= 0 || !isPickingUp)
            {
                other.gameObject.transform.parent = null;
            }
        }
    }
}
