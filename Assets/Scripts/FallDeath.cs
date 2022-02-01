using UnityEngine;

public class FallDeath : MonoBehaviour
{
       public bool isDead=false;

private void OnTriggerEnter2D(Collider2D other) {
        
            isDead = true;
    }
}

