using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player_controller : MonoBehaviour
{
    public Animator animator;
    public GroundCheck groundCheckObject;
    public ScoreController scoreControllerObject;
    public FallDeath fallDeathObject;
    public Enemy1Controller enemy1ControllerObj;
    private Rigidbody2D playerRigidBody;

    private float verticalInput;
    private float horizontalInput;
    private int Score;

    [SerializeField] private float speedForce = 0.0f;
    [SerializeField] private float jumpForce = 0.0f;
    [SerializeField] private float health = 100f;
    [SerializeField] private float EnemyDamage = 50f;


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
    }

    void Update()
    {       
        //player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        isCrouching = Input.GetKey(KeyCode.LeftControl);
        isStaffAttacking = Input.GetKey(KeyCode.E);
        isShooting = Input.GetKey(KeyCode.Space);
        isPushing = Input.GetKey(KeyCode.Tab);
        

        PlayerAnimations();
    }

    void FixedUpdate() {

        PlayerMovements();
        isGrounded = groundCheckObject.isGrounded;
        isDead = fallDeathObject.isDead || isDead;
        isHurting = enemy1ControllerObj.isHurting;
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
        animator.SetBool("isHurting",isHurting);
        
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
        }
        if(health <= 0){
            isDead = true;
            RefreshScene();
        }
         
    }
    public IEnumerator DelayAction(){
        //Debug.Log(Time.time);
        yield return new WaitForSeconds(2f);
        //Debug.Log(Time.time);
    }

    void RefreshScene()
    {
        SceneManager.LoadScene(1);
    }
    public void PickUp(){
        scoreControllerObject.IncreaseKeys(1);
    }
}
