using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Animator animator;
    public Transform groundCheck;
    private Rigidbody2D rgBd2D;
    public LayerMask whatIsLayerMask;

    public float speedForce;
    public float jumpForce;
    public float groundCheckRadius;

    public bool isGrounded = false;




    void Awake() {
        rgBd2D = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {   
        
        //player input
        float speed = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Vertical");
        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        bool isStaffAttaking = Input.GetKey(KeyCode.E);
        bool isShooting = Input.GetKey(KeyCode.Space);
        bool isPushing = Input.GetKey(KeyCode.Tab);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsLayerMask);
        PlayAnimation(speed, jump, isCrouching, isStaffAttaking, isShooting,isPushing,isGrounded);
        MoveCharacter(speed,jump,isGrounded);

    }

    private void MoveCharacter(float speed,float jump,bool isGrounded)
    {
        //player horizontal movement
        Vector3 position = transform.position;
        position.x += speed * speedForce * Time.deltaTime;
        transform.position = position;

        //player vertical movement
        if (jump > 0 && isGrounded)
        {
            rgBd2D.AddForce(new Vector2(0,jumpForce),ForceMode2D.Force);
            Debug.Log(jumpForce);
        }

    }

    private void PlayAnimation(float speed,float jump, bool isCrouching,bool isStaffAttaking, bool isShooting,bool isPushing, bool isGrounded)
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
        if (jump > 0 && isGrounded)
        {
            animator.SetBool("isJumping",true);
        }
        else if (jump == 0 )
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
