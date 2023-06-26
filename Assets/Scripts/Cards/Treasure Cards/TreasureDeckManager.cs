using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections;

public class TreasureDeckManager : MonoBehaviour
{
    public GameObject[] treasureCards;
    public GameObject[] treasureDiscardPile;
    public GameObject[] treasureHand;

    public GameObject[] floodDiscardPile;
    public WaterMeterSlider waterMeterSlider;

    public FloodDeck floodDeck;
    public GameObject[] initialCardArray; // Array of cards at the start of the game
    public PlayerDeck playerDeck;

    public GameObject FullText;



    public void Start()
    {
        ShuffleDeck();
        DrawInitialCards();
    }

    public void DrawInitialCards()
    {
        DrawTopCards(treasureCards, playerDeck);
    }

    public void DrawCardsOnClick()
    {
        DrawTopCards(playerDeck.decklist.ToArray(), playerDeck);
    }
    public void ShuffleDeck()
    {
        // Shuffle the treasure cards using any shuffling algorithm
        // Example:
        for (int i = 0; i < treasureCards.Length; i++)
        {
            int randomIndex = Random.Range(i, treasureCards.Length);
            GameObject temp = treasureCards[randomIndex];
            treasureCards[randomIndex] = treasureCards[i];
            treasureCards[i] = temp;
        }
    }

    public void DrawTopCards(GameObject[] cardArray, PlayerDeck playerDeck)
    {
        // Check if there are at least 2 cards in the cardArray
        if (cardArray.Length < 2)
        {
            Debug.Log("Insufficient cards in the array.");
            return;
        }

        // Create a separate array to store the drawn cards
        GameObject[] drawnCards = new GameObject[2];

        // Draw the top 2 cards from the cardArray and add them to the decklist
        for (int i = 0; i < 2; i++)
        {
            drawnCards[i] = cardArray[i];
            AddCardToDeck(playerDeck, drawnCards[i]);
        }

        // Instantiate the sprites of the drawn cards to a specific position
        Vector3 position = new Vector3(0f, 0f, 0f); // Replace with your desired position
        foreach (GameObject card in drawnCards)
        {
            Instantiate(card.GetComponent<SpriteRenderer>().sprite, position, Quaternion.identity);
        }
    }
    public IEnumerator ShowFullTextForDuration(float duration)
    {
        FullText.SetActive(true);
        yield return new WaitForSeconds(duration);
        FullText.SetActive(false);
    }

    private void AddCardToDeck(PlayerDeck playerDeck, GameObject card)
    {
        if (playerDeck.decklist.Count >= 5)
        {
            StartCoroutine(ShowFullTextForDuration(2.5f));
            return;
        }

        playerDeck.decklist.Add(card);
    }


}