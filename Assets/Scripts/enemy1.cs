using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    [SerializeField] private float leftBound;
    [SerializeField] private float rightBound;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isfacingLeft = true;

    private void Update() {
        if (transform.position.x > leftBound && isfacingLeft)    //going left
        {
            Vector3 position = transform.position;
            position.x -= moveSpeed * Time.deltaTime;
            transform.position = position;
        }else if (isfacingLeft)                                //flipping to right
        {
            isfacingLeft = false;
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale=scale;
        }else if (transform.position.x < rightBound && !isfacingLeft) //going right
        {
            Vector3 position = transform.position;
            position.x += moveSpeed * Time.deltaTime;
            transform.position = position;
        }else if (!isfacingLeft)     
        {
            isfacingLeft = true;
            Vector3 scale = transform.localScale;
            scale.x = -1f *Mathf.Abs(scale.x);
            transform.localScale=scale;
        }
    }

}
