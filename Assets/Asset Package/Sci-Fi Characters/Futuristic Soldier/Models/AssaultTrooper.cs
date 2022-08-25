using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultTrooper : MonoBehaviour
{

    Animator anim;
    CharacterController controller;

    public float speed = 5f;
    public float rotationRate = 180f;
    public float jumpForce = 6f;
    public string player =  "P1";

    Vector3 velocity; //Use to store gravity to apply to the player

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleLook();
        HandleMovement();
    }

    void HandleLook()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X " + player) * rotationRate * Time.deltaTime, 0);
    }
    
    
    
    
    void HandleMovement(){
        //Calculate acceleration due to gravity

        velocity += Physics.gravity * Time.deltaTime;

        if(Input.GetButtonDown("Jump" + player) && controller.isGrounded)
        {
            velocity += transform.up * jumpForce;
        }

        if (Input.GetButtonDown("Fire1" + player))
        {
            anim.SetTrigger("Attack");
        }

        Vector3 v = new Vector3(
            Input.GetAxis("Horizontal"),  0, Input.GetAxis("Vertical"));

        //Movement controls
        anim.SetFloat("MoveX", v.x);
        anim.SetFloat("MoveY", v.z);
        anim.SetBool("IsGrounded", controller.isGrounded);

        controller.Move((transform.TransformDirection (v.normalized) * speed + velocity) * Time.deltaTime);


        //Null velocity if you hit the ground
        if (controller.isGrounded) velocity = Vector3.zero;
    }
}
