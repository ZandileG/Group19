using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureDeckInput : MonoBehaviour
{
    public TreasureDeckManager TreasureDeck; // Reference to the FloodDeck script
    public Transform treasureContainer; // Transform of the container GameObject
    

    private void OnMouseDown()
    {
        TreasureDeck.ShuffleDeck();
        TreasureDeck.DrawTreasureCards(2);
    }





    /*    private void Start()
    {
        ShuffleDeck();
        DrawTreasureCards(2);
    }*/
}