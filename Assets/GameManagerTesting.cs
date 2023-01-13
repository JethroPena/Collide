using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManagerTesting : MonoBehaviour
{

    public Animator animatorPlayerAttk; // The playerattack's animator component
    public Animator animatorPlayerDodge; // The attackerdodge's animator component
    public Animator animatorEnemyAttk; // The enemyattack's animator component
    public Animator animatorEnemyDodge; // The enemydodge's animator component
    public Animator animatorPlayerUlti; // The playerulti's animator component
    public Animator animatorEnemyUlti; // The enemyulti's animator component
    public float ultiDuration = 1f; // The ultimate attack animation lasts for 1.5 seconds
    public int ultiPower = 30; // The amount of damage the player does with the ultimate attack
    public float dodgeDuration = 0.9f; // Dodge lasts for 0.5 seconds
    public float attackDuration = 0.3f; // The attack animation lasts for 0.5 seconds
    public int attackPower = 10; // The amount of damage the attacker does with each attack
    public GameObject player1; // The player being attack
    public GameObject player2; // The enemy being attack
    public int playerOneEnergy = 0; // Player 1's starting energy
    public int playerTwoEnergy = 0; // Player 2's starting energy
    public int energyGainPerHit = 10; // Change 10 to the desired energy gain value
    public int energyCostPerUlti = 50; // The amount of energy required to use the ultimate attack
    public bool ultimateAttackEnabled = false; // Flag to track if the ultimate attack is enabled for the player
    public FightingHandlerTesting fightingHandlertesting; // Add a reference to the fightingHandler_2P script

    // Flag to track whose turn it is
    public Image player1TurnIndicator;
    public Image player2TurnIndicator;
    private bool isPlayer1Turn = true;
    public float deathAnimationDuration = 0.3f;
    public bool isP1Colliding = false;
    public bool isP2Colliding = false;

    public Image player1HIT;




    void Start()
    {
        player1TurnIndicator.gameObject.SetActive(false);
        player2TurnIndicator.gameObject.SetActive(false);
        player1HIT.gameObject.SetActive(false);
    }


    void Update()

    {
        // Check if it's player 1's turn
        if (isPlayer1Turn)
        {
            // Show the player 1 turn indicator and set the color to green
            player1TurnIndicator.gameObject.SetActive(true);
            player1TurnIndicator.color = Color.green;

            // Hide the player 2 turn indicator
            player2TurnIndicator.gameObject.SetActive(false);
             // Otherwise, it's player 2's turn
        }
        else
            {   
            player2TurnIndicator.gameObject.SetActive(true);
            player2TurnIndicator.color = Color.green;

            // Hide the player 1 turn indicator
            player1TurnIndicator.gameObject.SetActive(false);
            }   


        if (Input.GetKeyDown(KeyCode.A))
            {
                isPlayer1Turn = false;
                StartCoroutine(Player1Attack());
            }
        
        if (Input.GetKey(KeyCode.S))
        {
            animatorPlayerDodge.SetTrigger("Dodge");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            isPlayer1Turn = false;
            StartCoroutine(WaitPlayer1Ulti());
        }

              //PLAYER 2 BUTTONS // 
        if (Input.GetKeyDown(KeyCode.J))
            {
                isPlayer1Turn = true;
                StartCoroutine(Player2Attack());
            }
        
        if (Input.GetKey(KeyCode.K))
        {
            animatorEnemyDodge.SetTrigger("Dodge");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            isPlayer1Turn = true;
            StartCoroutine(WaitPlayer2Ulti());
        }

    }   


        public void Player1Ulti(GameObject other)
        {
            // Check if the player has enough energy to use the ultimate attack
            if (playerOneEnergy >= energyCostPerUlti)
            {
            // Decrease the enemy's hit points
            fightingHandlertesting.playerTwoHP -= ultiPower;
            // Decrease the player's energy
            playerOneEnergy -= energyCostPerUlti;
            Debug.Log("Ult succesfully used");
            // Start the ultimate attack animation and wait for it to finish
            animatorPlayerUlti.SetBool("Ulti", true);
            }
        }   
        
        
        IEnumerator Player1Attack()
        {
            animatorPlayerAttk.SetTrigger("Attack");
            yield return new WaitForSeconds(attackDuration);
            if (isP1Colliding == true)
                {
                    fightingHandlertesting.TakeDamageP2(attackPower);
                    playerOneEnergy += energyGainPerHit;
                    
                    Debug.Log("P1: Attack Hit + Energy Gain");
                }


        }   

        IEnumerator WaitPlayer1Ulti()
        {
            // Attack the player with the ultimate attack
            Player1Ulti(player2);
            // Wait for the ultimate attack animation to finish
            yield return new WaitForSeconds(ultiDuration);
            // Allow the other player to make a move
            isPlayer1Turn = false;
        }


         public void Player2Ulti(GameObject other)
        {
            // Check if the player has enough energy to use the ultimate attack
            if (playerOneEnergy >= energyCostPerUlti)
            {
            // Decrease the enemy's hit points
            fightingHandlertesting.playerTwoHP -= ultiPower;
            // Decrease the player's energy
            playerOneEnergy -= energyCostPerUlti;
            Debug.Log("Ult succesfully used");
            // Start the ultimate attack animation and wait for it to finish
            animatorEnemyUlti.SetBool("Ulti", true);
            }
        }
        
        
        IEnumerator Player2Attack()
        {
            animatorEnemyAttk.SetTrigger("Attack");
            yield return new WaitForSeconds(attackDuration);
            if (isP2Colliding == true)
                {
                    fightingHandlertesting.TakeDamageP1(attackPower);
                    playerTwoEnergy += energyGainPerHit;
                    Debug.Log("P2: Attack Hit + Energy Gain");
                }
        }

        IEnumerator WaitPlayer2Ulti()
        {
            // Attack the player with the ultimate attack
            Player2Ulti(player2);
            // Wait for the ultimate attack animation to finish
            yield return new WaitForSeconds(ultiDuration);
            // Allow the other player to make a move
            isPlayer1Turn = false;
        }
        
}
