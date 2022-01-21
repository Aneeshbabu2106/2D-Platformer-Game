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
        float speed = Input.GetAxis("Horizontal");
        float jump = Input.GetAxisRaw("Vertical");
        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        bool isStaffAttaking = Input.GetKey(KeyCode.E);
        bool isShooting = Input.GetKey(KeyCode.Space);
        bool isPushing = Input.GetKey(KeyCode.Tab);


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
            animator.SetBool("isCrouching",true);
        }
        else
        {
           animator.SetBool("isCrouching",false); 
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

        //shooting
        if (isShooting)
        {
            animator.SetBool("isShooting",true);
        }
        else
        {
           animator.SetBool("isShooting",false); 
        }

        //pushing
        if (isPushing)
        {
            animator.SetBool("isPushing",true);
        }
        else
        {
           animator.SetBool("isPushing",false); 
        }


    }
}
