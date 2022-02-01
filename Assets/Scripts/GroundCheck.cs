using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded=false;

private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<CompositeCollider2D>() != null){ //checking for platfrom
            isGrounded = true;
        }
    }

private void OnTriggerExit2D(Collider2D other) {
     if(other.gameObject.GetComponent<CompositeCollider2D>() != null){
            isGrounded = false;
        }
    
}
}

