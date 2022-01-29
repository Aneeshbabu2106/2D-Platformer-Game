using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Player_controller>() != null) //checking player
        {
            Player_controller playerController = other.gameObject.GetComponent<Player_controller>();
            playerController.PickUp();
            Destroy(gameObject);
        }
    }
}
