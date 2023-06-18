using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] TreasureCards;
    public GameObject[] Players;
    private void ShuffleTreasureCards()
    {
        int cardCount = TreasureCards.Length;
        if (cardCount >= 6)
        {
            for (int i = 0; i < cardCount; i++)
            {
                int randomIndex = Random.Range(i, cardCount);
                GameObject tempCard = TreasureCards[randomIndex];
                TreasureCards[randomIndex] = TreasureCards[i];
                TreasureCards[i] = tempCard;
            }

            for (int i = cardCount - 1; i >= cardCount - 2; i--)
            {
                Destroy(TreasureCards[i]);
                TreasureCards[i] = null;
            }
            
            for (int i = 0; i < 4; i++)
            {
                TreasureCards[i].SetActive(true);
            }

            int playerCount = Players.Length;
            for (int i = 0; i < Mathf.Min(playerCount, 4); i++)
            {
                GameObject player = Players[i];
                if (player != null)
                {
                  
                    Transform cardDisplay = player.transform.GetChild(0);

                    
                    GameObject card = Instantiate(TreasureCards[i], cardDisplay.position, Quaternion.identity);
                    card.transform.SetParent(cardDisplay, false);
                }
            }
        }
    }

    public void Start()
    {
        ShuffleTreasureCards();
    }


    /*public void StartGame()   
    {
         // Initialize game state and setup the game board
        currentPlayerIndex = 0;
        gameEnded = false;
        // Perform any other necessary initialization tasks
    }

    public void EndGame()
    {
            // Clean up game state and show the game-over screen
        gameEnded = true;
          // Perform any necessary clean-up tasks
    }

    public void NextTurn()
    {

            //Extra - Once a turn is done it, ensure currentplayerindex++;
        if (gameEnded)
        {
            Debug.LogWarning("The game has ended. Cannot proceed to the next turn.");
            return;
        }

            // Perform actions to end the current player's turn, update game state, and proceed to the next player's turn
         // For example, you could update the currentPlayerIndex, handle any game events or triggers, etc.

        // Check for win/loss conditions and end the game if necessary


        /*if (CheckForWinCondition())
        {
            // Handle win condition
            EndGame();
        }
        else if (CheckForLossCondition())
        {
            // Handle loss condition
            EndGame();
        }*/
    /* private bool CheckForWinCondition()
    {
        // Implement the logic to check if the players have won the game
        // Return true if the win condition is met, otherwise return false
    }

private bool CheckForLossCondition()
    {
        // Implement the logic to check if the players have lost the game
        // Return true if the loss condition is met, otherwise return false
    }*/

    //} 
}
