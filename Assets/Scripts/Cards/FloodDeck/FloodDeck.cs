using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodDeck : MonoBehaviour
{
    public GameObject floodCardPrefab; // Flood card prefab
    public Sprite[] cardSprites; // Array of card sprites
    public Transform deckTransform; // Transform of the deck GameObject
    private List<int> floodDrawPile; // Flood draw pile
    private List<int> floodDiscardPile; // Flood discard pile

    void Start()
    {
         Debug.Log("FloodDeck: Start");
        ShuffleFloodDeck();
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
    Debug.Log("FloodDeck: DrawTopCards");
    for (int i = 0; i < count; i++)
    {
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
            floodCard.SetCardSprite(cardSprites[cardIndex]);
        }
    }
}

}
