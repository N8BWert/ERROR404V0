using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bacteria3AI : MonoBehaviour
{
    List<GameObject> ICLocations = new List<GameObject>();
    NavMeshAgent agent;
    Animator anim;
    public float Disttodamage = 8f;
    public float DistToCenter;
    public bool isStunned = false;
    public int randNum;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ICLocations = new List<GameObject>(GameObject.FindGameObjectsWithTag("IC"));
        Random.Range(0, ICLocations.Count);
    }

    void Update()
    {
        ICLifeCheck();
        StunCheck();
        DistanceCheck();
    }
    void ICLifeCheck()
    {
        if(ICLocations[randNum] == null)
        {
            anim.SetBool("isDead", true);
            Destroy(gameObject, 0.25f);
        }
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
    void DistanceCheck()
    {
        DistToCenter = Vector3.Distance(gameObject.transform.position, ICLocations[randNum].transform.position);
        if (DistToCenter > Disttodamage && !isStunned)
        {
            agent.isStopped = false;
            anim.SetBool("isMoving", true);
            anim.SetBool("isAttacking", false);
            agent.SetDestination(ICLocations[randNum].transform.position);
        }
        if (Disttodamage >= DistToCenter && !isStunned)
        {
            anim.SetBool("isMoving", false);
            anim.SetBool("isAttacking", true);
            agent.isStopped = true;
            ICLocations[randNum].GetComponent<ICLife>().Damage();
        }
        if (isStunned)
        {
            anim.SetBool("isMoving", false);
            anim.SetBool("isAttacking", false);
            agent.isStopped = true;
        }
    }
}
