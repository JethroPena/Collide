using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_6P : MonoBehaviour
{
   public Game2Manager_6P gameManager;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerOne"))
            {
                gameManager.isP2Colliding = true;
                Debug.Log("P2 Collide");
                gameManager.NextTurn();
            }
    }
}
