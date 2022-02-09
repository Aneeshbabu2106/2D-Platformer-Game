using UnityEngine;

public class EnemyPetrolling : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Collider2D wallColli2D;
    private Rigidbody2D enemyRB;
    public bool isfacingleft = false;
    public bool mustPetrol = true;
    private bool mustTurn = false;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {   
        if (mustPetrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);
            Patrol();
            
        }
    }

    private void Patrol()
    {
        if(mustTurn || wallColli2D.IsTouchingLayers(whatIsGround))
        {
            Flip();
        }
        enemyRB.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime,enemyRB.velocity.y);
        
    }
    public void Flip()
    {   
        mustPetrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1,transform.localScale.y); //flip enemy
        walkSpeed *= -1;
        isfacingleft = !isfacingleft;                                                                       //flip movement direction
        mustPetrol = true;                                                                      
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheck.position,groundCheckRadius);
        
    }
}
