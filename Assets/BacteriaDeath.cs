using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaDeath : MonoBehaviour
{
    public bool isActive = true;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void DIE()
    {
        isActive = false;
        anim.SetBool("isDead", true);
        Destroy(gameObject, 0.5f);
    }
}
