
using UnityEngine;

public class MovingPlatfrom : MonoBehaviour
{
    public Transform pos1,pos2;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
    Player_controller playerController;

    void Start()
    {
        nextPos = startPos.position;
    }

    void Update()
    {
        if(transform.position == pos1.position)
        {
            nextPos =pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nextPos =pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position,nextPos,speed * Time.deltaTime);  
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(pos1.position,pos2.position);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<Player_controller>() == null)
        {
            playerController.onMovingPlatfrom = true;
        }
    }
    // private void OnCollisionExit2D(Collision2D other) {
    //     if(other.gameObject.GetComponent<Player_controller>() == null)
    //     {
    //         playerController.onMovingPlatfrom = false;
    //     }
        
    // }
}
