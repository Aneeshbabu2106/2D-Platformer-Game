using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D playerRigidBody;

    [SerializeField] private float speedForce = 0.0f;
    [SerializeField] private float jumpForce = 0.0f;

    private float jump;
    private float speed;

    private bool isCrouching = false;
    private bool isStaffAttacking = false;
    private  bool isShooting = false;
    private bool isPushing = false;
    [SerializeField] private bool isGrounded = false;
    
    void Awake() {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {       
        //player input
        speed = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Vertical");
        isCrouching = Input.GetKey(KeyCode.LeftControl);
        isStaffAttacking = Input.GetKey(KeyCode.E);
        isShooting = Input.GetKey(KeyCode.Space);
        isPushing = Input.GetKey(KeyCode.Tab);
    }

    void FixedUpdate() {

        PlayAnimation();
        MoveCharacter(); 
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("_platform"))
        {
            isGrounded = true;
        }
    }

    private void MoveCharacter()
    {
        //player horizontal movement
        Vector3 position = transform.position;
        position.x += speed * speedForce * Time.deltaTime;
        transform.position = position;

        //player vertical movement
        if (jump > 0 && isGrounded)
        {
            playerRigidBody.AddForce(new Vector2(0,jumpForce),ForceMode2D.Force);
            Debug.Log(jumpForce);
            isGrounded = false;
        }
    }

    private void PlayAnimation ()
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
        if (isStaffAttacking)
        {
            animator.SetBool("isStaffAttacking",true);
        }
        else
        {
           animator.SetBool("isStaffAttacking",false); 
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

        //jumping mechanics
        if (jump > 0 && isGrounded)
        {
            animator.SetBool("isJumping",true);  
        }
        else 
        {
           animator.SetBool("isJumping",false);
        } 
    }
}
