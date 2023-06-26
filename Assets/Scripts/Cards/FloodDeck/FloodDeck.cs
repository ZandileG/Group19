using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodDeck : MonoBehaviour
{
    public GameObject floodCardPrefab; // Flood card prefab
    public Sprite[] cardSprites; // Array of card sprites
    public Transform deckTransform; // Transform of the deck GameObject
    public GameObject[] islandTiles; // Array of Island tile game objects
    private List<int> floodDrawPile; // Flood draw pile
    private List<int> floodDiscardPile; // Flood discard pile
    public Transform discardPileTransform; // Transform of the discard pile GameObject
    private List<GameObject> floodDiscardPileCards; // List of card game objects in the flood discard pile
    private int waterLevelCount;



    void Start()
    {
    Debug.Log("FloodDeck: Start");
    ShuffleFloodDeck();
    floodDiscardPile = new List<int>();
    floodDiscardPileCards = new List<GameObject>();
    }

    void ShuffleFloodDeck()
    {
        Debug.Log("FloodDeck: ShuffleFloodDeck");
        floodDrawPile = new List<int>();
        for (int i = 0; i < cardSprites.Length; i++)
        {
            floodDrawPile.Add(i);
        }

        for (int i = 0; i < floodDrawPile.Count; i++)
        {
            int temp = floodDrawPile[i];
            int randomIndex = Random.Range(i, floodDrawPile.Count);
            floodDrawPile[i] = floodDrawPile[randomIndex];
            floodDrawPile[randomIndex] = temp;
        }
    }

  public void DrawTopCards(int count, Transform container)
{
         drawnCards.Clear();
        Debug.Log("FloodDeck: DrawTopCards");
        for (int i = 0; i < count; i++)
        {
        // Check if the floodDrawPile is empty
        if (floodDrawPile.Count == 0)
        {
            // Shuffle the cards from the floodDiscardPile back into the floodDrawPile
            ShuffleDiscardPileIntoDrawPile();
        }

        if (floodDrawPile.Count > 0)
        {
            int cardIndex = floodDrawPile[0];
            floodDrawPile.RemoveAt(0);

            // Instantiate a new instance of the card prefab
            GameObject cardInstance = Instantiate(floodCardPrefab, container);

            // Set the position and rotation of the card instance
            cardInstance.transform.position = deckTransform.position;

            // Set the sprite of the card instance
            FloodCard floodCard = cardInstance.GetComponent<FloodCard>();
            if (floodCard == null)
            {
                Debug.LogError("FloodDeck: DrawTopCards: floodCard is null");
            }
            else
            {
                floodCard.SetCardSprite(cardSprites[cardIndex]);
            }

            // Flip the corresponding Island tile to its "flooded" side
            FlipIslandTile(cardIndex);

            // Wait for 1 second before placing the drawn Flood card in the discard pile
            StartCoroutine(PlaceCardInDiscardPileWithDelay(cardInstance, cardIndex, 1f));
        }
  }
}

private IEnumerator PlaceCardInDiscardPileWithDelay(GameObject card, int cardIndex, float delay)
{
    yield return new WaitForSeconds(delay);
    PlaceCardInDiscardPile(card, cardIndex);
}

void ShuffleDiscardPileIntoDrawPile()
{
    Debug.Log("FloodDeck: ShuffleDiscardPileIntoDrawPile");

    // Move all cards from floodDiscardPile and floodDiscardPileCards back into their respective draw piles
    while (floodDiscardPile.Count > 0)
    {
        int cardIndex = floodDiscardPile[0];
        GameObject card = floodDiscardPileCards[0];
        floodDiscardPile.RemoveAt(0);
        floodDiscardPileCards.RemoveAt(0);
        floodDrawPile.Add(cardIndex);

        // Move the card game object back to the position of the deck
        card.transform.position = deckTransform.position;
    }

    // Shuffle floodDrawPile
    for (int i = 0; i < floodDrawPile.Count; i++)
    {
        int temp = floodDrawPile[i];
        int randomIndex = Random.Range(i, floodDrawPile.Count);
        floodDrawPile[i] = floodDrawPile[randomIndex];
        floodDrawPile[randomIndex] = temp;
    }
}

/*void ShuffleDiscardPileIntoDrawPile()
{
    Debug.Log("FloodDeck: ShuffleDiscardPileIntoDrawPile");

    // Check if all island tiles are inactive
    bool allIslandTilesInactive = true;
    foreach (GameObject islandTile in islandTiles)
    {
        if (islandTile.activeSelf)
        {
            allIslandTilesInactive = false;
            break;
        }
    }

    // Only shuffle the discard pile back into the draw pile if not all island tiles are inactive
    if (!allIslandTilesInactive)
    {
        // Move all cards from floodDiscardPile and floodDiscardPileCards back into their respective draw piles
        while (floodDiscardPile.Count > 0)
        {
            int cardIndex = floodDiscardPile[0];
            GameObject card = floodDiscardPileCards[0];
            floodDiscardPile.RemoveAt(0);
            floodDiscardPileCards.RemoveAt(0);
            floodDrawPile.Add(cardIndex);

            // Move the card game object back to the position of the deck
            card.transform.position = deckTransform.position;
        }

        // Shuffle floodDrawPile
        for (int i = 0; i < floodDrawPile.Count; i++)
        {
            int temp = floodDrawPile[i];
            int randomIndex = Random.Range(i, floodDrawPile.Count);
            floodDrawPile[i] = floodDrawPile[randomIndex];
            floodDrawPile[randomIndex] = temp;
        }
    }
}
*/


private HashSet<int> drawnCards = new HashSet<int>();
private int flipIslandTileCounter = 0;

public void FlipIslandTile(int cardIndex)
{Debug.Log("FloodDeck: FlipIslandTile");
 flipIslandTileCounter++;
    Debug.Log("FloodDeck: FlipIslandTile: flipIslandTileCounter = " + flipIslandTileCounter);



        if (drawnCards.Contains(cardIndex))
            return;

        if (drawnCards.Count >= waterLevelCount)
            return;
        // Find the Island tile that corresponds to the given card index
        GameObject islandTile = islandTiles[cardIndex];

    // Find the FloodedIslandTile child of the Island tile
    Transform floodedIslandTile = islandTile.transform.parent.parent.Find("FloodedTiles").GetChild(cardIndex);

    if (floodedIslandTile.gameObject.activeSelf && drawnCards.Contains(cardIndex))
    {
        // Deactivate the floodedIslandTile
        floodedIslandTile.gameObject.SetActive(false);

        // Reset the rotation of the Island tile
        islandTile.transform.rotation = Quaternion.identity;

        // Deactivate the Island tile
        islandTile.SetActive(false);
    }
    else
    {
        // Start a coroutine to animate the flipping of the Island tile
        Debug.Log("FloodDeck: FlipIslandTile: StartCoroutine");
        StartCoroutine(FlipIslandTileCoroutine(islandTile, floodedIslandTile));
    }

    drawnCards.Add(cardIndex);
}


private IEnumerator FlipIslandTileCoroutine(GameObject islandTile, Transform floodedIslandTile)
{
    Debug.Log("FloodDeck: FlipIslandTileCoroutine");

    // Check if the floodedIslandTile is already active
    if (floodedIslandTile.gameObject.activeSelf)
    {
        // Deactivate the floodedIslandTile
        floodedIslandTile.gameObject.SetActive(false);

        // Reset the rotation of the Island tile
        islandTile.transform.rotation = Quaternion.identity;
    }

    // Animate the rotation of the Island tile over time
    for (float t = 0; t < 1; t += Time.deltaTime)
    {
        islandTile.transform.rotation = Quaternion.Euler(0, Mathf.Lerp(0, 180, t), 0);
        yield return null;
    }

    // Enable the FloodedIslandTile and disable the IslandTile
    floodedIslandTile.gameObject.SetActive(true);
    islandTile.SetActive(false);

    // Reset the rotation of the Island tile
    islandTile.transform.rotation = Quaternion.identity;
}



/*private IEnumerator FlipIslandTileCoroutine(GameObject islandTile, Transform floodedIslandTile)
{
    Debug.Log("FloodDeck: FlipIslandTileCoroutine");

    // Check if the floodedIslandTile is already active
    if (floodedIslandTile.gameObject.activeSelf)
    {
        // Deactivate the floodedIslandTile
        floodedIslandTile.gameObject.SetActive(false);

        // Reset the rotation of the Island tile
        islandTile.transform.rotation = Quaternion.identity;
    }
    else if (islandTile.activeSelf)
    {
        // Animate the rotation of the Island tile over time
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            islandTile.transform.rotation = Quaternion.Euler(0, Mathf.Lerp(0, 180, t), 0);
            yield return null;
        }

        // Enable the FloodedIslandTile and disable the IslandTile
        floodedIslandTile.gameObject.SetActive(true);
        islandTile.SetActive(false);

        // Reset the rotation of the Island tile
        islandTile.transform.rotation = Quaternion.identity;
    }
}
*/

public void PlaceCardInDiscardPile(GameObject card, int cardIndex)
{
    Debug.Log("FloodDeck: PlaceCardInDiscardPile: cardIndex = " + cardIndex);


    // Move the card game object to the position of the discard pile
    card.transform.position = discardPileTransform.position;

    // Add the given card index and game object to their respective discard piles
    floodDiscardPile.Add(cardIndex);
    floodDiscardPileCards.Add(card);
}
    public void UpdateWaterLevelCount(int count)
    {
        waterLevelCount = count;
    }
}
