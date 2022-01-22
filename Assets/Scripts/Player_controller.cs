using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Animator animator;
    public float speedForce=4f;
    void Update()
    {   
        
        //player input
        float speed = Input.GetAxis("Horizontal");
        float jump = Input.GetAxisRaw("Vertical");
        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        bool isStaffAttaking = Input.GetKey(KeyCode.E);
        bool isShooting = Input.GetKey(KeyCode.Space);
        bool isPushing = Input.GetKey(KeyCode.Tab);
        PlayAnimation(speed, jump, isCrouching, isStaffAttaking, isShooting,isPushing);
        MoveCharacter(speed);

    }

    private void MoveCharacter(float speed)
    {
        Vector3 position = transform.position;
        position.x += speed * speedForce * Time.deltaTime;
        transform.position = position;

    }

    private void PlayAnimation(float speed,float jump, bool isCrouching,bool isStaffAttaking, bool isShooting,bool isPushing)
    {
        
        //animating run, idle animation
        animator.SetFloat("speed",Mathf.Abs(speed));

        //flipping
        Vector3 scale = transform.localScale;
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
