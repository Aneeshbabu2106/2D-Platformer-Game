using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    public bool isHurting = false;
    Player_controller playerControllerObj;
  private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.GetComponent<Player_controller>() != null)//checking player
      {
          playerControllerObj = other.gameObject.GetComponent<Player_controller>();
          playerControllerObj.EnemyAttack();
          isHurting = true;
      }
  }
  private void OnCollisionExit2D(Collision2D other) {
      if(other.gameObject.GetComponent<Player_controller>() != null)//checking player
      {
          isHurting = false;
      }
  }
}
