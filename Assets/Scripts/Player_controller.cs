using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");

        float jump = Input.GetAxisRaw("Jump");
        animator.SetFloat("speed",Mathf.Abs(speed));
        

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }else if(speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        if (jump > 0)
        {
            animator.SetBool("isJumping",true);
        }
        else if (jump ==0 )
        {
           animator.SetBool("isJumping",false); 
        }



        transform.localScale=scale;

    }
}
