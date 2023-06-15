using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] TreasureCards;
    private int currentPlayerIndex = 0; // Index of the current player
    private bool gameEnded = false; // Indicates whether the game has ended
    // Add other variables as needed

    private void ShuffleTreasureCards()
    {
        int cardCount = TreasureCards.Length;
        while (cardCount > 1)
        {
            cardCount--;
            int randomIndex = Random.Range(0, cardCount + 1);
            GameObject tempCard = TreasureCards[randomIndex];
            TreasureCards[randomIndex] = TreasureCards[cardCount];
            TreasureCards[cardCount] = tempCard;
        }
    }

    public void Start()
    {
        ShuffleTreasureCards();
    }


    public void StartGame()
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
    }



    
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

}
