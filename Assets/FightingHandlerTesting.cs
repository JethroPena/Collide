using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FightingHandlerTesting : MonoBehaviour
{   
    public static List<string> Winners;
    public TextMeshProUGUI playerOneName;
    public TextMeshProUGUI playerTwoName;
    public TextMeshProUGUI playerOneHPUI;
    public TextMeshProUGUI playerTwoHPUI;
    private GameManager_2P gameManager;
    public int energyGainPerHit = 10; // Change 10 to the desired energy gain value
    public Slider healthBarSliderP1;
    public Slider healthBarSliderP2;
    public Slider ultimateEnergySliderP1;
    public Slider ultimateEnergySliderP2;
 
    public int playerOneHP;
    public int playerTwoHP;

    void Awake()
    {
        playerOneName.text = NameHandler.playerNames[0];
        playerTwoName.text = NameHandler.playerNames[1];
        playerOneHP = NameHandler.playerHP;
        playerTwoHP = NameHandler.playerHP;
    }
    // Start is called before the first frame update
    void Start()
    {
        Winners = new List<string>();

    }

    // Update is called once per frame
    void Update()
    {
        playerOneHPUI.text = playerOneHP + "";
        playerTwoHPUI.text = playerTwoHP + "";

        // Update the health bar to reflect the current health of the player
        healthBarSliderP1.value = playerOneHP / (float)NameHandler.playerHP;
        healthBarSliderP2.value = playerTwoHP / (float)NameHandler.playerHP;
        StartCoroutine(healthChecker());

        ultimateEnergySliderP2.value = gameManager.playerTwoEnergy;
    }

    public void TakeDamageP2(int damage)
    {
        playerTwoHP -= damage;

        // Update the UI text element to show the updated health value
        playerTwoHPUI.text = playerTwoHP + "";

        // Update the health bar to reflect the current health of the player
        healthBarSliderP2.value = playerTwoHP / (float)NameHandler.playerHP;
        // Print a debug log message
        Debug.Log("P2 Health decreased: " + damage);
    }


     public void TakeDamageP1(int damage)
    {
        playerOneHP -= damage;

        // Update the UI text element to show the updated health value
        playerOneHPUI.text = playerOneHP + "";

        // Update the health bar to reflect the current health of the player
        healthBarSliderP1.value = playerOneHP / (float)NameHandler.playerHP;
        // Print a debug log message
        Debug.Log("P1 Health decreased: " + damage);
    }


    IEnumerator healthChecker()
    {   

        //GAME 1
        if (playerOneHP <= 0)
        {
            NameHandler.winner = 1;
            yield return new WaitForSeconds(.1f);
            SceneManager.LoadScene("OverallWinner");
           

        }

        if (playerTwoHP <= 0)
        {
            NameHandler.winner = 0;
            yield return new WaitForSeconds(.1f);
            SceneManager.LoadScene("OverallWinner");
        }

    }
}
