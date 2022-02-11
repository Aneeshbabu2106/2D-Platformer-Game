using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    public bool isHurting = false;
    PlayerDamage playerDamageObj;
    private void Start() {
        ;
    }
    private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.GetComponent<PlayerDamage>() != null)//checking player
      {
          isHurting = true;
          //GetComponent<Animator>().SetTrigger("isAttacking");
          playerDamageObj = other.gameObject.GetComponent<PlayerDamage>();
          playerDamageObj.HurtCheck(isHurting);
          playerDamageObj.EnemyAttack(transform);
           
      }
  }
  private void OnCollisionExit2D(Collision2D other) {
      if(other.gameObject.GetComponent<PlayerDamage>() != null)//checking player
      {
          isHurting = false;
          playerDamageObj.HurtCheck(isHurting);
      }
  }
}
