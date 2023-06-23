using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public GameObject[] players; // array of player prefabs
    public GameObject[] PlayerPanels; // array of player prefabs
    public float turnDuration = 5f; // duration of each turn in seconds
    private int currentPlayer = 0; // variable to keep track of current player's turn

    void Start()
    {
        UpdatePlayerVisibility();
        StartCoroutine(ChangeTurns());
    }

    IEnumerator ChangeTurns()
    {
        while (true)
        {
            yield return new WaitForSeconds(turnDuration); // wait for turn duration
            currentPlayer = (currentPlayer + 1) % players.Length; // update current player
            UpdatePlayerVisibility();
        }
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



