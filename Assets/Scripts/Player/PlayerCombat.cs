using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private int damageAmount = 50;
    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }
    void Attack()
    {   //Play attack animation
        animator.SetTrigger( "staffAttacking" );

        //Detect Enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().EnemyTakeDamage(damageAmount);
        }
        //Damage Enemies
    }

    private void OnDrawGizmos() {
        if (attackPoint != null)
        {
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);   
        }
        
    }
   
}
