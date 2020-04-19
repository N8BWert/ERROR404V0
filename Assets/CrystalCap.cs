using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCap : MonoBehaviour
{
    public int Cap = 20;
    private List<GameObject> Crystals = new List<GameObject>();
    public bool StopCrystals = false;
    public GameObject CrystalPlacer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Crystals = new List<GameObject>(GameObject.FindGameObjectsWithTag("Crystal"));
        if(Crystals.Count >= Cap)
        {
            StopCrystals = true;
            CrystalPlacer.SetActive(false);
        }
        else
        {
            CrystalPlacer.SetActive(true);
        }
    }
}
