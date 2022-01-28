using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Animator animator;
    public GroundCheck groundCheckObject;
    private Rigidbody2D playerRigidBody;

    private float verticalInput;
    private float horizontalInput;

    [SerializeField] private float speedForce = 0.0f;
    [SerializeField] private float jumpForce = 0.0f;

    private bool isGrounded = false;
    private bool isCrouching = false;
    private bool isStaffAttacking = false;
    private  bool isShooting = false;
    private bool isPushing = false;
    
    
    void Awake() {
        //getting components
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {       
        //player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isCrouching = Input.GetKey(KeyCode.LeftControl);
        isStaffAttacking = Input.GetKey(KeyCode.E);
        isShooting = Input.GetKey(KeyCode.Space);
        isPushing = Input.GetKey(KeyCode.Tab);
    }

    void FixedUpdate() {

        PlayerAnimations();
        PlayerMovements();
        isGrounded=groundCheckObject.isGrounded;
    }
    
    private void PlayerMovements()
    {
        //player horizontal movement
        Vector3 position = transform.position;
        position.x += horizontalInput * speedForce * Time.fixedDeltaTime;
        transform.position = position;

        //player vertical movement
        if (verticalInput > 0 && isGrounded && !isPushing && !isStaffAttacking)
        {
            playerRigidBody.AddForce(new Vector2(0,jumpForce),ForceMode2D.Force);
            //Debug.Log(jumpForce);
        }
    }

    private void PlayerAnimations()
    { 
        //setting animator parameters
        animator.SetFloat("speed",Mathf.Abs(horizontalInput));
        animator.SetFloat("verticalSpeed",playerRigidBody.velocity.y);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isCrouching",isCrouching);                   //Crouching
        animator.SetBool("isStaffAttacking",isStaffAttacking);         //staff attacking
        animator.SetBool("isShooting",isShooting);                     //shooting      
        animator.SetBool("isPushing",isPushing);                       //pushing
        
        //flipping
        Vector3 scale = transform.localScale;
        if (horizontalInput < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        }else if(horizontalInput > 0){
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale=scale;

        //jumping 
        if (verticalInput > 0 && isGrounded){
            animator.SetBool("isJumping",true);  
        }else {
            animator.SetBool("isJumping",false);
        } 
    }
}
