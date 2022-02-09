using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    public Animator animator;
    EnemyPetrolling enemyPatrol;
    Rigidbody2D enemyRB;
    public Transform playerPos;
    public int maxHealth = 100;
    int currenthealth;
    public float deadTimer;
    public float hurtTimer;
    private float deadTimeRemaining;
    private float hurtTimeRemaining;
    private bool  isDead = false;
    private bool isHurt = false;

    void Start()
    {
        deadTimeRemaining = deadTimer;
        hurtTimeRemaining = hurtTimer;
        currenthealth = maxHealth;
        animator = GetComponent<Animator>();
        enemyPatrol = GetComponent<EnemyPetrolling>();
        enemyRB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        if(isDead)
        {
            enemyRB.gravityScale = 0;
            GetComponent<Collider2D>().enabled = false;
            if(deadTimeRemaining < 0)
            {
                gameObject.SetActive(false);
            }
            deadTimeRemaining -= Time.fixedDeltaTime;
        }
        if(isHurt && !isDead)
        {
            if(hurtTimeRemaining < 0)
            {
                enemyPatrol.mustPetrol = true;
                isHurt = false;
            }
            hurtTimeRemaining -= Time.fixedDeltaTime;

        }
        
    }
    public void EnemyTakeDamage(int damage)
    {   
        currenthealth -= damage;
        hurtTimeRemaining =  hurtTimer;
        if (currenthealth <= 0)
        {
           Die();      
        }

        if((transform.position.x > playerPos.position.x && enemyPatrol.isfacingleft !=true) ||
            (transform.position.x < playerPos.position.x && enemyPatrol.isfacingleft ==true))
        {
            enemyPatrol.Flip();
        }

        enemyPatrol.mustPetrol = false;                //stop moving when hurt
        enemyRB.velocity = Vector2.zero;
  
        isHurt = true;
        animator.SetTrigger("isHurt");

    }

    private void Die()
    {
        isDead = true;
        animator.SetBool("isDead", isDead);

    }

}
