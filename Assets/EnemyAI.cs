using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public float seeDistance = 20;
    GameObject Player;
    private float distanceToPlayer;
    public bool isStunned = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
         StunCheck();
         DistanceCheck();
        ActivityCheck();
    }
    void ActivityCheck ()
    {
        if(!GetComponent<BacteriaDeath>().isActive)
        {
            agent.isStopped = true;
        }
    }
    void StunCheck()
    {
        if(gameObject.GetComponent<AntiBacterialActions>().currentStunTime > 0)
        {
            isStunned = true;
        }
        else
        {
            isStunned = false;
        }
    }
    void DistanceCheck ()
    {
        distanceToPlayer = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        if(distanceToPlayer <= seeDistance)
        {
            anim.SetBool("inCamera", true);
        }
        else
        {
            anim.SetBool("inCamera", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("seesPlayer", true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && !isStunned)
        {
            agent.isStopped = false;
            agent.SetDestination(other.gameObject.transform.position);
        }
        if (isStunned)
        {
            agent.isStopped = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("seesPlayer", false);
        }
    }
}
