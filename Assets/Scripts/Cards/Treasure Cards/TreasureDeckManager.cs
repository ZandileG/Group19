using UnityEngine;

public class TreasureDeckManager : MonoBehaviour
{
    public GameObject[] treasureCards;
    public GameObject[] treasureDiscardPile;
    public GameObject[] treasureHand;

    public GameObject[] floodDiscardPile;
    public WaterMeterSlider waterMeterSlider;
    public FloodDeck floodDeck;

    public int cardsToDrawAtEnd;

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

    public void DrawTreasureCards(int numCards)
    {
        for (int i = 0; i < numCards; i++)
        {
            GameObject drawnCard = treasureCards[0];
            treasureCards[0] = null;
            ShiftArrayElementsLeft(treasureCards);

            if (drawnCard.CompareTag("WaterRiseCard"))
            {
                HandleWatersRiseCard(drawnCard);
            }
            else
            {
                AddCardToHand(drawnCard);
            }
        }
    }

    private void ShiftArrayElementsLeft(GameObject[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            array[i - 1] = array[i];
        }

        array[array.Length - 1] = null;
    }

    private void HandleWatersRiseCard(GameObject watersRiseCard)
    {
        waterMeterSlider.MoveWaterLevelMarker();

        if (floodDiscardPile.Length > 0)
        {
            ShuffleFloodDiscardPile();
        }
        else
        {
            waterMeterSlider.MoveWaterLevelMarker();
        }

        AddCardToDiscardPile(watersRiseCard);
    }

    private void ShuffleFloodDiscardPile()
    {
        // Shuffle the flood discard pile using any shuffling algorithm
        // Example:
        for (int i = 0; i < floodDiscardPile.Length; i++)
        {
            int randomIndex = Random.Range(i, floodDiscardPile.Length);
            GameObject temp = floodDiscardPile[randomIndex];
            floodDiscardPile[randomIndex] = floodDiscardPile[i];
            floodDiscardPile[i] = temp;
        }

        // Move the shuffled cards to the flood draw pile
        foreach (GameObject card in floodDiscardPile)
        {
            // Add card to the flood draw pile
            // Example:
            // floodDeck.AddCardToDrawPile(card);
        }

        // Clear the flood discard pile
        floodDiscardPile = new GameObject[0];
    }

    private void AddCardToHand(GameObject card)
    {
        for (int i = 0; i < treasureHand.Length; i++)
        {
            if (treasureHand[i] == null)
            {
                treasureHand[i] = card;
                break;
            }
        }
    }

    private void AddCardToDiscardPile(GameObject card)
    {
        for (int i = 0; i < treasureDiscardPile.Length; i++)
        {
            if (treasureDiscardPile[i] == null)
            {
                treasureDiscardPile[i] = card;
                break;
            }
        }
    }
}