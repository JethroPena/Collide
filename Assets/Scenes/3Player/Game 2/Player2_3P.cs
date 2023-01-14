using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_3P : MonoBehaviour
{
 public Game2Manager_3P gameManager;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerTwo"))
            {
                gameManager.isP1Colliding = true;
                Debug.Log("P1 Collide");
                gameManager.NextTurn();
            }
    }
}
