using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public GameObject[] players; // array of player prefabs
    public GameObject[] PlayerPanels; // array of player prefabs
    public float turnDuration = 5f; // duration of each turn in seconds
    private int currentPlayer = 0; // variable to keep track of current player's turn
    private int[] counters; // counters for the text
    public Text[] counterTexts; // references to the counter text elements

    void Start()
    {
        UpdatePlayerVisibility();
        counters = new int[players.Length]; // initialize the counter variables

        for (int i = 0; i < players.Length; i++)
        {
            counters[i] = 0; // set initial counter value to 0
            counterTexts[i].text = counters[i].ToString(); // set initial counter text value
        }
    }

    public void NextTurn()
    {
        counters[currentPlayer]++; // Increment the counter for the current player

        if (counters[currentPlayer] >= 3)
        {
            currentPlayer = (currentPlayer + 1) % players.Length; // Switch to the next player
            counters[currentPlayer] = 0; // Reset the counter for the next player
        }

        for (int i = 0; i < players.Length; i++)
        {
            counterTexts[i].text = counters[i].ToString("Actions: " + counters[currentPlayer]); // Update the counter text for each player
        }

        UpdatePlayerVisibility();
    }

    void UpdatePlayerVisibility()
    {
        for (int i = 0; i < players.Length; i++)
        {
            TextMeshProUGUI turnText = players[i].transform.Find("yourTurnTxt").GetComponent<TextMeshProUGUI>(); // find TextMeshProUGUI element in player prefab with tag "tmpr"
            if (i == currentPlayer)
            {
                turnText.enabled = true; // show current player's text
                PlayerPanels[i].SetActive(true);
            }
            else
            {
                turnText.enabled = false; // hide other player's text
                PlayerPanels[i].SetActive(false);
            }
        }
    }
}



