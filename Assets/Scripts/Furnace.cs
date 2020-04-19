using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        anim.SetBool("On", true);
    }
    void OffAnimation()
    {
        anim.SetBool("On", false);
    }
}
