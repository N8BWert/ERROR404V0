using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float moveSpeed = 2;
    Animator anim;
    CharacterController cc;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= moveSpeed;
        StunCheck();
        MovementCheck();
        PickUpCheck();
        cc.Move(moveDirection);
    }
    void MovementCheck ()
    {
        if (Mathf.Abs(moveDirection.magnitude) > 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
    void StunCheck ()
    {
        if(Input.GetButton("Fire1"))
        {
            anim.SetBool("Stun", true);
            moveDirection = new Vector3(0f, 0f, 0f);
        }
        else
        {
            anim.SetBool("Stun", false);
        }
    }
    void PickUpCheck ()
    {
        if(Input.GetButton("Fire2"))
        {
            anim.SetBool("isPickingUp", true);
        }
        else
        {
            anim.SetBool("isPickingUp", false);
        }
    }
}
