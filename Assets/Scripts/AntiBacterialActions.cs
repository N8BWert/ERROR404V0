using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiBacterialActions : MonoBehaviour
{
    public float stunTime = 3;
    private Animator anim;
    public float currentStunTime;
    public Material stunMaterial;
    public Material normalMaterial;
    public GameObject materialHolder;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StunCalculations();
    }
    void StunCalculations ()
    {
        if(currentStunTime > 0)
        {
            currentStunTime -= Time.deltaTime;
        }
        if(currentStunTime > 0)
        {
            anim.SetBool("isStunned", true);
            materialHolder.GetComponent<SkinnedMeshRenderer>().material = stunMaterial;

        }
        else
        {
            anim.SetBool("isStunned", false);
            materialHolder.GetComponent<SkinnedMeshRenderer>().material = normalMaterial;
        }
    }
    public void Stun()
    {
        currentStunTime += stunTime * Time.deltaTime;
    }
}
