﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaDeath : MonoBehaviour
{
    public bool isActive = true;
    private Animator anim;
    GameObject DeathLocation;
    float Dist;
    public float deathDist = 6;
    GameObject Manager;
    List<GameObject> DeathLocations = new List<GameObject>();

    private void Start()
    {
        DeathLocation= GameObject.FindGameObjectWithTag("Furnace");
        anim = GetComponent<Animator>();
        Manager = GameObject.FindGameObjectWithTag("Manager");
    }
    private void Update()
    {
        Deathdestination();
        if(Dist <= deathDist)
        {
            DIE();
        }
    }
    void Deathdestination ()
    {
            Dist = Vector3.Distance(gameObject.transform.position, DeathLocation.transform.position);
    }
    void DIE()
    {
        isActive = false;
        Manager.GetComponent<CountDown>().AddTime();
        anim.SetBool("isDead", true);
        Destroy(gameObject, 0.5f);
    }
}
