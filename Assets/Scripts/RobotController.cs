using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float moveSpeed = 2;
    Animator anim;
    CharacterController cc;
    public float YDistance;

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
        Rotator();
        PickUpCheck();
        cc.Move(moveDirection);
        YCheck();
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
    void YCheck ()
    {
        if(gameObject.transform.position.y > YDistance)
        {
            transform.position = new Vector3(gameObject.transform.position.x, YDistance, gameObject.transform.position.z);
        }
    }
    void Rotator()
    {
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }
    void StunCheck ()
    {
        if(Input.GetButton("Fire1"))
        {
            anim.SetBool("Stun", true);
            moveDirection *= 0;
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
