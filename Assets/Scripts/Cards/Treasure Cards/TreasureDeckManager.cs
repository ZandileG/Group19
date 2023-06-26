using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Collections;

public class TreasureDeckManager : MonoBehaviour
{
    [Header("Treasure Deck")]
    public GameObject[] treasureCards;
    public GameObject[] treasureDiscardPile;
    public GameObject[] treasureHand;
    public GameObject[] initialCardArray;

    [Header("Flood Deck")]
    public FloodDeck floodDeck;
    public GameObject[] floodDiscardPile;
    

    [Header("Player Decks")]
    public PlayerDeck PlayerDeck1;
    public PlayerDeck2 PlayerDeck2;
    public Transform[] CardPrefabs;

    public WaterMeterSlider waterMeterSlider;
    public GameObject FullText;

    public void Start()
    {
        ShuffleDeck();
        DrawInitialCards();
    }

    public void DrawInitialCards()
    {
        DrawTopCards(treasureCards, PlayerDeck1);
    }

    public void DrawCardsOnClick()
    {
        DrawTopCards(PlayerDeck1.decklist.ToArray(), PlayerDeck1);

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
        // Instantiate the sprites of the drawn cards based on the card prefabs' transforms
        for (int i = 0; i < drawnCards.Length; i++)
        {
            Transform cardPrefabTransform = CardPrefabs[i % CardPrefabs.Length]; // Loop through the card prefabs in a circular manner
            Vector3 position = cardPrefabTransform.position; // Use the transform position of the card prefab

            // Instantiate the card from the player's deck list at the specified position
            GameObject instantiatedCard = Instantiate(playerDeck.decklist[i], position, Quaternion.identity);
            instantiatedCard.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);

            // Optionally, you can set the instantiated card as a child of another GameObject
            // instantiatedCard.transform.SetParent(someParentTransform);

            // Add the instantiated card to the player's decklist
            playerDeck.decklist[i] = instantiatedCard;
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
        if (PlayerDeck1.decklist.Count == 5)
        {
            StartCoroutine(ShowFullTextForDuration(2.5f));
            return;
        }

        treasureCards = treasureCards.Skip(count).ToArray();
    }

}