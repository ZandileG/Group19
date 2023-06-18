using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckInput : MonoBehaviour
{
    public FloodDeck floodDeck; // Reference to the FloodDeck script
    public Transform container; // Transform of the container GameObject

    void OnMouseDown()
    {
        // Draw the top 6 cards from the flood deck when the deck is clicked
        floodDeck.DrawTopCards(6, container);
    }
    
        
    }

