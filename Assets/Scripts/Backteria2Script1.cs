using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Backteria2Script1 : MonoBehaviour
{
    GameObject CommandCenter;
    NavMeshAgent agent;
    Animator anim;
    public float Disttodamage = 10f;
    public float DistToCenter;
    public bool isStunned = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        CommandCenter = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        //ActivityCheck();
        StunCheck();
        DistanceCheck();
    }
    void StunCheck()
    {
        if (gameObject.GetComponent<AntiBacterialActions>().currentStunTime > 0)
        {
            isStunned = true;
        }
        else
        {
            isStunned = false;
        }
    }
    /*void ActivityCheck()
    {
        if (!GetComponent<BacteriaDeath>().isActive)
        {
            agent.isStopped = true;
        }
    }*/
    void DistanceCheck()
    {
        DistToCenter = Vector3.Distance(gameObject.transform.position, CommandCenter.transform.position);
        if(DistToCenter > Disttodamage && !isStunned)
        {
            agent.isStopped = false;
            anim.SetBool("isMoving", true);
            anim.SetBool("isAttacking", false);
            agent.SetDestination(CommandCenter.transform.position);
        }
        if(Disttodamage >= DistToCenter && !isStunned)
        {
            anim.SetBool("isMoving", false);
            anim.SetBool("isAttacking", true);
            agent.isStopped = true;
            CommandCenter.GetComponent<CountDown>().LessTime();
        }
        if(isStunned)
        {
            anim.SetBool("isMoving", false);
            anim.SetBool("isAttacking", false);
            agent.isStopped = true;
        }
    }
}
