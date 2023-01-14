using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5_6P : MonoBehaviour
{
  
    public Game5Manager_6P gameManager;



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
