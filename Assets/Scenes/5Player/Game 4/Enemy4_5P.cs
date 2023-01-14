using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4_5P : MonoBehaviour
{
    public Game4Manager_5P gameManager;



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