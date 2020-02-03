using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drummercontroller : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 20f;
    public bool inPerson = true;
    private Animator anim;
    private CharacterController controller;
    public Transform lookAtPoint;
    public bool sprint = false;
    public bool onQuest = false;
    public string questItem = "";
    public Camera myCam;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (inPerson)
        {
            float xInput = Input.GetAxis("Horizontal");
            float yInput = Input.GetAxis("Vertical");
            bool walking = anim.GetBool("Walking");
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                sprint = true;
            else
                sprint = false;
            if (xInput != 0)
            {
                Turn(xInput);
            }
            if (yInput != 0)
            {
                Move(yInput);
                if (!walking)
                {
                    anim.SetBool("Walking", true);
                }
            }
            else
            {
                anim.SetBool("Walking", false);
            }

        }
    }

    private void Turn(float xInput)
    {
        //lookAtPoint.transform.RotateAround(transform.position, transform.up, turnSpeed * Time.deltaTime);
        transform.Rotate((transform.up * xInput) * turnSpeed * Time.deltaTime);
        //transform.LookAt(lookAtPoint);
    }

    private void Move(float yInput)
    {
        //controller.SimpleMove((transform.forward * yInput) * speed * Time.deltaTime);
        if (sprint)
        {
            transform.position += (transform.forward * yInput) * Time.deltaTime * speed * 2;
            anim.SetBool("Running", true);
        }
        else
        {
            transform.position += (transform.forward * yInput) * Time.deltaTime * speed;
            anim.SetBool("Running", false);
        }
    }
}

