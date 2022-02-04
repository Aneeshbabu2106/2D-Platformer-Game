using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPetrolling : MonoBehaviour
{
    public Transform leftBound;
    public Transform rightBound;
    private float xLeftBound;
    private float xRightBound;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isfacingLeft = true;
    private void Start() {
        {
            xLeftBound = leftBound.position.x;
            xRightBound = rightBound.position.x;
        }
    }

    private void Update() {
        Vector3 scale = transform.localScale;
        Vector3 position = transform.position;
        if (transform.position.x > xLeftBound && isfacingLeft)          //going left
        { 
            position.x -= moveSpeed * Time.deltaTime;
        }
        else if (isfacingLeft)                                        //flipping to right
        {
            isfacingLeft = false;
            scale.x = Mathf.Abs(scale.x);
            
        }
        else if (transform.position.x < xRightBound && !isfacingLeft)  //going right
        {
            position.x += moveSpeed * Time.deltaTime;
        }
        else if (!isfacingLeft)                                       //flipping to left
        { 
            isfacingLeft = true;
            scale.x = -1f *Mathf.Abs(scale.x);
        }
        transform.position = position;
        transform.localScale = scale; 
    }

}
