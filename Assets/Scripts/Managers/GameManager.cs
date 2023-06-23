using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Players in game: ")]
    public GameObject[] Players;

    [Header("Adventure Cards List: ")]
    public GameObject[] AdventureCards;

    [Header("Treasure Cards List: ")]
    public GameObject[] TreasureCards;
    public GameObject[] TreasureDiscardPile;



    public void Start()
    {
        ShuffleAdventureCards();
    }

    private void ShuffleAdventureCards()
    {
        int cardCount = AdventureCards.Length;
        if (cardCount >= 6)

        {
            for (int i = 0; i < cardCount; i++)
            {
                int randomIndex = Random.Range(i, cardCount);
                GameObject tempCard = AdventureCards[randomIndex];
                AdventureCards[randomIndex] = AdventureCards[i];
                AdventureCards[i] = tempCard;
            }

            for (int i = cardCount - 1; i >= cardCount - 2; i--)
            {
                Destroy(AdventureCards[i]);
                AdventureCards[i] = null;
            }

            for (int i = 0; i < 4; i++)
            {
                AdventureCards[i].SetActive(true);
            }

            int playerCount = Players.Length;
            for (int i = 0; i < Mathf.Min(playerCount, 4); i++)
            {
                GameObject player = Players[i];
                if (player != null)
                {

                    Transform cardDisplay = player.transform.GetChild(0);


                    GameObject card = Instantiate(AdventureCards[i], cardDisplay.position, Quaternion.identity);
                    card.transform.SetParent(cardDisplay, false);
                }
            }
        }
    }
}





/*Treasure Deck 


private List<TreasureCard> DrawTreasureCards(int numCardsToDraw)
{
    List<TreasureCard> drawnCards = new List<TreasureCard>();

    for (int i = 0; i < numCardsToDraw; i++)
    {
        if (treasureDeck.Count > 0)
        {
            TreasureCard drawnCard = treasureDeck[0];
            treasureDeck.RemoveAt(0);
            drawnCards.Add(drawnCard);

            // Handle Waters Rise! card
            if (drawnCard is WatersRiseCard)
            {
                HandleWatersRiseCard(drawnCard as WatersRiseCard);
                drawnCards.Remove(drawnCard); // Remove the Waters Rise! card from the drawn cards
                treasureDiscardPile.Add(drawnCard); // Discard the Waters Rise! card
            }
        }
        else
        {
            // Handle when the Treasure deck runs out
            HandleTreasureDeckRunOut();
            break;
        }
    }

    return drawnCards;
}

private void HandleWatersRiseCard(WatersRiseCard watersRiseCard)
{
    // Move the Water Level marker up
    waterLevelMarker.MoveUp();

    // Shuffle the Flood discard pile and place it on top of the Flood draw pile
    floodDrawPile.AddRange(floodDiscardPile);
    floodDiscardPile.Clear();
    ShuffleFloodCards();

    // Discard the Waters Rise! card to the Treasure discard pile
    treasureDiscardPile.Add(watersRiseCard);
}

private void HandleTreasureDeckRunOut()
{
    // Shuffle the Treasure discard pile and form a new Treasure deck
    treasureDeck.AddRange(treasureDiscardPile);
    treasureDiscardPile.Clear();
    ShuffleTreasureCards();
}

private void TakeActionsAndDrawCards()
{
    // Player takes actions

    // Draw 2 cards from the top of the Treasure deck
    List<TreasureCard> drawnCards = DrawTreasureCards(2);

    // Add the drawn cards to the player's face-up hand
    playerHand.AddRange(drawnCards);
}
Note: The implementation assumes the existence of classes such as TreasureCard, WatersRiseCard, CardType, WaterLevelMarker, and appropriate deck lists like treasureDeck, treasureDiscardPile, floodDrawPile, floodDiscardPile, and playerHand. Make sure to adapt the code according to your specific implementation and class structures.





User
modify drawtreasure cards methods, and use an array of gameobjects instead of a list
ChatGPT
To modify the DrawTreasureCards() method to use an array of GameObjects instead of a list, you can make the following changes:

Change the method signature to return an array of GameObjects instead of a list.
csharp
Copy code
private GameObject[] DrawTreasureCards(int numCardsToDraw)
{
    GameObject[] drawnCards = new GameObject[numCardsToDraw];
    // Rest of the code remains the same
    ...
    return drawnCards;
}
Replace the drawnCards.Add(drawnCard) line with drawnCards[i] = drawnCard.
csharp
Copy code
if (treasureDeck.Count > 0)
{
    TreasureCard drawnCard = treasureDeck[0];
    treasureDeck.RemoveAt(0);
    drawnCards[i] = drawnCard;
    // Rest of the code remains the same
    ...
}
Replace the drawnCards.Remove(drawnCard) line with drawnCards[i] = null.
csharp
Copy code
if (drawnCard is WatersRiseCard)
{
    HandleWatersRiseCard(drawnCard as WatersRiseCard);
    drawnCards[i] = null; // Remove the Waters Rise! card from the drawn cards
    treasureDiscardPile.Add(drawnCard); // Discard the Waters Rise! card
}
Update the TakeActionsAndDrawCards() method to handle the array of GameObjects instead of a list.
csharp
Copy code
private void TakeActionsAndDrawCards()
{
    // Player takes actions

    // Draw 2 cards from the top of the Treasure deck
    GameObject[] drawnCards = DrawTreasureCards(2);

    // Add the drawn cards to the player's face-up hand
    for (int i = 0; i < drawnCards.Length; i++)
    {
        if (drawnCards[i] != null)
        {
            GameObject drawnCard = drawnCards[i];
            // Add the drawn card to the player's hand or handle it as needed
            // For example, you might have a HandManager script that handles the player's hand
            handManager.AddCardToHand(drawnCard);
        }
    }
}
Make sure to adjust the code according to your specific implementation, including the GameObject array, the actual handling of the drawn cards, and any relevant scripts or components involved in managing the player's hand.





User
    private List<TreasureCard> DrawTreasureCards(int numCardsToDraw)
    {
        List<TreasureCard> drawnCards = new List<TreasureCard>();

        for (int i = 0; i < numCardsToDraw; i++)
        {
            if (treasureDeck.Count > 0)
            {
                TreasureCard drawnCard = treasureDeck[0];
                treasureDeck.RemoveAt(0);
                drawnCards.Add(drawnCard);

                // Handle Waters Rise! card
                if (drawnCard is WatersRiseCard)
                {
                    HandleWatersRiseCard(drawnCard as WatersRiseCard);
                    drawnCards.Remove(drawnCard); // Remove the Waters Rise! card from the drawn cards
                    treasureDiscardPile.Add(drawnCard); // Discard the Waters Rise! card
                }
            }
            else
            {
                // Handle when the Treasure deck runs out
                HandleTreasureDeckRunOut();
                break;
            }
        }

        return drawnCards;
    } modify this to use an array of gameobjects instead of a list
ChatGPT
To modify the DrawTreasureCards() method to use an array of GameObjects instead of a list, you can make the following changes:

csharp
Copy code
private GameObject[] DrawTreasureCards(int numCardsToDraw)
{
    GameObject[] drawnCards = new GameObject[numCardsToDraw];

    for (int i = 0; i < numCardsToDraw; i++)
    {
        if (treasureDeck.Count > 0)
        {
            TreasureCard drawnCard = treasureDeck[0];
            treasureDeck.RemoveAt(0);
            GameObject cardObject = ConvertTreasureCardToGameObject(drawnCard); // Convert TreasureCard to GameObject
            drawnCards[i] = cardObject;

            // Handle Waters Rise! card
            if (drawnCard is WatersRiseCard)
            {
                HandleWatersRiseCard(drawnCard as WatersRiseCard);
                drawnCards[i] = null; // Remove the Waters Rise! card from the drawn cards
                treasureDiscardPile.Add(drawnCard); // Discard the Waters Rise! card
            }
        }
        else
        {
            // Handle when the Treasure deck runs out
            HandleTreasureDeckRunOut();
            break;
        }
    }

    return drawnCards;
}

private GameObject ConvertTreasureCardToGameObject(TreasureCard treasureCard)
{
    // Convert the TreasureCard to a corresponding GameObject representation
    // Instantiate the GameObject, set its properties, and return it
    // You'll need to customize this method based on your specific implementation
    // For example, you might have a prefab for each type of TreasureCard

    // Example code assuming you have a prefab for each type of TreasureCard:
    if (treasureCard is HelicopterLiftCard)
    {
        return Instantiate(helicopterLiftCardPrefab);
    }
    else if (treasureCard is SandbagsCard)
    {
        return Instantiate(sandbagsCardPrefab);
    }
    else if (treasureCard is TreasureCard)
    {
        return Instantiate(treasureCardPrefab);
    }
    else
    {
        return null; // Invalid card type
    }
} */
