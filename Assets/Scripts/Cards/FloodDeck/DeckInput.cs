using UnityEngine;

public class DeckInput : MonoBehaviour
{
    public FloodDeck floodDeck; // Reference to the FloodDeck script
    public Transform container; // Transform of the container GameObject
    public GameObject FloodDisplay;

    private void Start()
    {
        FloodDisplay.SetActive(false);
    }

    private void OnMouseDown()
    {
        DisplayDrawnCards();
        StartCoroutine(DisplayPanelForSeconds(12f));
    }

    private void DisplayDrawnCards()
    {
        floodDeck.DrawTopCards(6, container);
    }

    private System.Collections.IEnumerator DisplayPanelForSeconds(float seconds)
    {
        FloodDisplay.SetActive(true);

        yield return new WaitForSeconds(seconds);

        FloodDisplay.SetActive(false);
    }
}



