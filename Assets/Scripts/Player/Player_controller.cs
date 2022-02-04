using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player_controller : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private Animator animator;
    private CapsuleCollider2D colli2D;
    public GroundCheck groundCheckObject;
    public ScoreController scoreControllerObject;
    public GameOverController gameOverCtrlObj;
    public FallDeath fallDeathObject;
    public Enemy1Controller enemy1ControllerObj;


    private float verticalInput;
    private float horizontalInput;
    private int Score;

    [SerializeField] private float speedForce = 0.0f;
    [SerializeField] private float jumpForce = 0.0f;
    public float health = 3f;
    [SerializeField] private float EnemyDamage = 1f;
    [SerializeField] private float hurtMoveForce = 0.0f;



    private bool isGrounded = false;
    private bool isCrouching = false;
    private bool isStaffAttacking = false;
    private  bool isShooting = false;
    private bool isPushing = false;
    private bool isDead = false;
    private bool isHurting = false;
    
    
    
    void Awake() {
        //getting components
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        colli2D = gameObject.GetComponent<CapsuleCollider2D>();

    }

    void Update()
    {       
        
        GettingInput();
        isDead = fallDeathObject.isDead || isDead;
        isHurting = enemy1ControllerObj.isHurting;
        PlayerAnimations();
    
    }

    void GettingInput()
    {
        //player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        isCrouching = Input.GetKey(KeyCode.LeftControl);
        isStaffAttacking = Input.GetKey(KeyCode.E);
        isShooting = Input.GetKey(KeyCode.Space);
        isPushing = Input.GetKey(KeyCode.Tab);
    }

    void FixedUpdate() {
        PlayerMovements();
        isGrounded = groundCheckObject.isGrounded;
        
    }
    
    private void PlayerMovements()
    {
        if(!isDead){

        //flipping
        Vector3 scale = transform.localScale;
        if (horizontalInput < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        }else if(horizontalInput > 0){
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale=scale;

        //player horizontal movement
        Vector3 position = transform.position;
        position.x += horizontalInput * speedForce * Time.fixedDeltaTime;
        transform.position = position;

        }
        //player vertical movement
        if (verticalInput > 0 && isGrounded && !isPushing && !isStaffAttacking && !isDead){
            playerRigidBody.AddForce(new Vector2(0,jumpForce),ForceMode2D.Force);
            //Debug.Log(check++);
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
        animator.SetBool("isDied",isDead);                             //died
        animator.SetBool("isHurting",isHurting);                       //Hurting
        
        //jumping 
        if (verticalInput > 0 && isGrounded){
            animator.SetBool("isJumping",true);  
        }else {
            animator.SetBool("isJumping",false);
        } 
    }
    public void EnemyAttack()
    {
        health -= EnemyDamage;
        Debug.Log(health);
        if(health > 0){
            //isHurting
            HurtMovement();
        }
        if(health <= 0){
            isDead = true;
            //remove detection by enemy;
            animator.SetBool("isDied",isDead);                             //died
            StartCoroutine(DelayAction());
        }
         
    }
    public void HurtMovement()
    {
        Vector3 position = transform.position;
        if(transform.localScale.x == 1) //need good logic use enemy position
        {
            position.x -= hurtMoveForce;
        } else{
            position.x += hurtMoveForce;
        }
        transform.position = position;
        Debug.Log(health);
    }
    public IEnumerator DelayAction(){

        yield return new WaitForSeconds(1f);
        gameOverCtrlObj.PlayerDied();
        isDead = false;
        this.enabled=false;
    }

    
    public void PickUp(){
        scoreControllerObject.IncreaseKeys(1);
    }
}
