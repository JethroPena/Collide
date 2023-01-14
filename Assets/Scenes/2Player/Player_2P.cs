using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2P : MonoBehaviour
{   
    public GameManager_2P gameManager;



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


