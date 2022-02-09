using System;
using System.Collections;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D playerRigidBody;
    public GameOverController gameOverCtrlObj;
    public float health = 3f;
    [SerializeField] private float EnemyDamage = 1f;
    [SerializeField] private float hurtMoveForce = 6f;
    private bool isDead = false;
    private bool isHurting = false;

    private void Start() {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update() {
        animator.SetBool("isHurting",isHurting);
    }
    public void EnemyAttack(Transform enemyTransform)
    {
        health -= EnemyDamage;
        if(health <= 0){
            isDead = true;
            //remove detection by enemy;
            animator.SetBool("isDied",isDead);

            GetComponent<Collider2D>().enabled = false;
            playerRigidBody.gravityScale = 0f;
                                     //died
            StartCoroutine(DelayAction());
        }
        if(health > 0){
            //isHurting
            HurtMovement(enemyTransform);
        }    
    }

    internal void HurtCheck(bool isHurt)
    {
        isHurting =isHurt;
    }

    public void HurtMovement(Transform enemyTransform)
    {
        if(transform.position.x < enemyTransform.position.x) 
        {
            playerRigidBody.velocity = new Vector2(1*-hurtMoveForce,playerRigidBody.velocity.y);
        } 
        else
        {
            playerRigidBody.velocity = new Vector2(1*hurtMoveForce,playerRigidBody.velocity.y);
        }
    }
    public IEnumerator DelayAction(){

        yield return new WaitForSeconds(1f);
        gameOverCtrlObj.PlayerDied();
        GetComponent<Player_controller>().enabled = false;
        
    }

}
