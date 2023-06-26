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
        for (int i = 0; i < treasureCards.Length; i++)
        {
            int randomIndex = Random.Range(i, treasureCards.Length);
            GameObject temp = treasureCards[randomIndex];
            treasureCards[randomIndex] = treasureCards[i];
            treasureCards[i] = temp;
        }

        //Checking if first card drawn is a water rise card
        if (treasureCards[0].tag == "WaterrRiseCard")
        {
            // Add the "Water Rise" card back to the treasure deck
            treasureCards = treasureCards.Concat(new GameObject[] { treasureCards[0] }).ToArray();

            // Get a different card from the treasure deck
            GameObject newCard = GetDifferentCard();

            // Replace the "Water Rise" card with the different card
            treasureCards[0] = newCard;

            // Shuffle the treasure deck again
            ShuffleDeck();
        }
    }

    private GameObject GetDifferentCard()
    {
        // Get a random card from the treasure deck
        int randomIndex = Random.Range(1, treasureCards.Length);
        return treasureCards[randomIndex];
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

        // Remove the top 2 cards from the treasure deck
        RemoveTopCards(2);

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

    private void RemoveTopCards(int count)
    {
        if (playerDeck.decklist.Count == 5)
        {
            StartCoroutine(ShowFullTextForDuration(2.5f));
            return;
        }

        treasureCards = treasureCards.Skip(count).ToArray();
    }

}