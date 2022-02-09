using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   
    public Animator animator;
    public int maxHealth = 100;
    int currenthealth;
    public float deadTimer;
    private float timeRemaining;
    private bool  isDead = false;

    void Start()
    {
        timeRemaining = deadTimer;
        currenthealth = maxHealth;
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate() {
        if(isDead == true)
        {
            if(timeRemaining < 0)
            {
                gameObject.SetActive(false);
            }
            timeRemaining -= Time.fixedDeltaTime;
        }
        
    }
    public void EnemyTakeDamage(int damage)
    {
        currenthealth -= damage; 
        animator.SetTrigger("isHurt");

        if (currenthealth <= 0)
        {
           Die();      
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetBool("isDead", isDead);

    }

}
