using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnManager : MonoBehaviour
{
    // Array of adventure cards
    public string[] adventureCards = new string[] { "Driver", "Messenger", "Navigator", "Pilot", "Explorer", "Engineer" };

    // Array of pawns
    public GameObject[] pawns;

    // Array of player slots
    public Transform[] playerSlots;

    void Start()
    {
        // Deactivate all pawns at the start of the game
        foreach (GameObject pawn in pawns)
        {
            pawn.SetActive(false);
        }
    }

    public void AssignPawnToPlayer(int playerIndex, int adventureCardIndex)
    {
        // Get the pawn associated with the adventure card
        GameObject pawn = pawns[adventureCardIndex];

        // Set the position of the pawn to the player slot
        pawn.transform.position = playerSlots[playerIndex].position;
        // Activate the pawn
        pawn.SetActive(true);
    }
}
