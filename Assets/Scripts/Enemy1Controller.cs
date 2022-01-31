using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    Player_controller PCObj;
  private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.GetComponent<Player_controller>() != null)
      {
          PCObj = other.gameObject.GetComponent<Player_controller>();
          PCObj.EnemyAttack();
      }
  }
}
