/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodDeck : MonoBehaviour
{
    public List<FloodCard> drawPile;
    public List<FloodCard> discardPile;

    //public GameObject deck; 
    public FloodCardObject cardPrefab; // Reference to the FloodCardObject prefab
    public Transform cardParent; // Parent transform for instantiated card prefabs

    void Start()
{
    // Load the cards
    LoadCards();

    // Shuffle the draw pile
    Shuffle();

    // Draw the top 6 cards
    for (int i = 0; i < 6; i++)
    {
        DrawCard();
    }
}


 public void DrawCard()
{
    // Get the top card from the draw pile
    FloodCard card = drawPile[0];
    drawPile.RemoveAt(0);

    // Add it to the discard pile
    discardPile.Add(card);

    // Instantiate a new card prefab in the scene
    FloodCardObject cardObject = Instantiate(cardPrefab, cardParent);

    // Set the properties of the card object
    cardObject.card = card;

    // Set the sprite of the card object to the sprite of the drawn card
    SpriteRenderer spriteRenderer = cardObject.GetComponent<SpriteRenderer>();
    if (spriteRenderer != null)
    {
        spriteRenderer.sprite = card.sprite;
    }
    else
    {
        Debug.LogError("Failed to set sprite for drawn card");
    }

    // Position the card object in the scene
    // ...
}

    public void Shuffle()
    {
        // Shuffle the draw pile
    for (int i = 0; i < drawPile.Count; i++)
    {
        // Generate a random index
        int randomIndex = Random.Range(i, drawPile.Count);

        // Swap the cards at the current index and the random index
        FloodCard temp = drawPile[i];
        drawPile[i] = drawPile[randomIndex];
        drawPile[randomIndex] = temp;
    }
    }


/*void LoadCards()
{
    // Load all card sprites from the Assets folder
    Sprite[] cardSprites = Resources.LoadAll<Sprite>("Art/Flooded Cards");

    // Check if any card sprites were loaded
    if (cardSprites.Length == 0)
    {
        Debug.LogError("Failed to load any card sprites");
        return;
    }

    // Create a new FloodCard object for each card sprite
    foreach (Sprite cardSprite in cardSprites)
    {
        // Create a new GameObject
        GameObject cardObject = new GameObject("FloodCard");

        // Add the FloodCard component to the GameObject
        FloodCard floodCard = cardObject.AddComponent<FloodCard>();

        // Set the properties of the FloodCard object
        floodCard.sprite = cardSprite;

        // Add the card to the draw pile
        drawPile.Add(floodCard);
    }



}*/





//old script, keeping it just in case

/*using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    public List<Card> discardPile = new List<Card>();

    void Start()
    {
        Sprite[] cardImages = new Sprite[24];
      

        string[] cardNames = new string[]
            { "BronzeGate",
            "CaveOfShadows",
            "CaveOfEmbers",
            "CliffsOfAbandon",
            "CopperGate",
            " CoralPalace",
            "CrimsonForest",
            "DunesOfDeception",
            "FoolsLanding",
            "GoldGate",
            "IronGate",
            "HowlingGarden",
            "LostLagoon",
            "MistyMarsh",
            "Observatory",
            "PhantomRock",
            "SilverGate",
            "TempleOfMoon",
            "TempleOfSun",
            "TidalPalace",
            "TwilightHollow",
            " WatchTower",
            "WhisperingGarden" };

for (int i = 0; i < cardNames.Length; i++)
    {
        string assetName = "Art/Resources/Flood Cards/" + cardNames[i];
        cardImages[i] = Resources.Load<Sprite>(assetName);

        // Create a new Card object and add it to the cards list
        Card card = new Card(cardNames[i], cardImages[i]);
        cards.Add(card);
    }
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    public Card DrawCard()
    {if (cards.Count == 0)
    {
        Debug.Log("No more cards in deck");
        
    }
        Card drawnCard = cards[0];
        discardPile.Add(drawnCard);
        cards.RemoveAt(0);
        return drawnCard;
    }
}
*/