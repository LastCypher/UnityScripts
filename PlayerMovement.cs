using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    private bool pm_grounded;
    
    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump =false;

    void Start()
    {

    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if(controller.Falling()==true)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
    }

    public void OnLanding ()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling",false);
        
    }
    void FixedUpdate ()
    {

      controller.Move(horizontalMove * Time.fixedDeltaTime,false, jump);
      jump = false;
    }
    
}