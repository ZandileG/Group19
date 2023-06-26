using UnityEngine;

public class DeckInput : MonoBehaviour
{
    public FloodDeck floodDeck; // Reference to the FloodDeck script
    public Transform container; // Transform of the container GameObject
    
    private void OnMouseDown()
    {
        DisplayDrawnCards();
    }

    private void DisplayDrawnCards()
    {
        floodDeck.DrawTopCards(6, container);
    }
}



