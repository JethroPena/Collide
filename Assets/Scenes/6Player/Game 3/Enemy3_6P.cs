using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3_6P : MonoBehaviour
{
    public Game3Manager_6P gameManager;



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