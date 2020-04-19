using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float moveSpeed = 2;
    Animator anim;
    CharacterController cc;
    public float distGround;
    public bool isGrounded = true;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        distGround = GetComponent<Collider>().bounds.extents.y + 0.2f;
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
        GroundCheck();
        Rotator();
        PickUpCheck();
        cc.Move(moveDirection);
    }
    void GroundCheck()
    {
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Ground").transform.position, gameObject.transform.position) > distGround)
        {
            isGrounded = true;
            moveDirection.y = -0.5f * Time.deltaTime;
        }
        else
        {
            isGrounded = false;
        }
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
    void Rotator()
    {
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(Vector3.zero, Vector3.up);
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
