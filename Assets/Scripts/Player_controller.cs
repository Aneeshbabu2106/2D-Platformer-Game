using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Animator animator;
    void Update()
    {   
        Vector3 scale = transform.localScale;

        //player input
        float speed = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Jump");
        bool isCrouching = Input.GetKey(KeyCode.S);
        bool isStaffAttaking = Input.GetKey(KeyCode.E);

        //animating run, idle animation
        animator.SetFloat("speed",Mathf.Abs(speed));

        //swiching sides
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }else if(speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale=scale;

        //jumping mechanics
        if (jump > 0)
        {
            animator.SetBool("isJumping",true);
        }
        else if (jump ==0 )
        {
           animator.SetBool("isJumping",false); 
        }

        //Crouching
        if (isCrouching)
        {
            animator.SetBool("iscrouching",true);
        }
        else
        {
           animator.SetBool("iscrouching",false); 
        }

        //staff attacking
        if (isStaffAttaking)
        {
            animator.SetBool("IsStaffAttaking",true);
        }
        else
        {
           animator.SetBool("IsStaffAttaking",false); 
        }

    }
}
