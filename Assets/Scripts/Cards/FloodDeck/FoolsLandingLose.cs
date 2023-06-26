using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoolsLandingLose : MonoBehaviour
{
    public GameObject islandTile; //assign the Fools' Landing tile in the Inspector
    public GameObject floodTile; // assign the Fools' Landing flooded tile in the Inspector
    public GameObject winOrLoseCanvas; // assign the WinOrLoseCanvas in the Inspector
    public GameObject loseText;

/*void Start()
    {
        floodTile = GameObject.Find("Flooded-islandTile_Fool'sLanding")
        islandTile = GameObject.Find("islandTile_Fool'sLanding"); 
    }*/

     void Update()
    {
        if (!islandTile.activeInHierarchy && !floodTile.activeInHierarchy) // check if the Fools' Landing tile is inactive
        {
            // end the game
            winOrLoseCanvas.SetActive(true); // activate the gameCanvas.gameObject.SetActive(false);
            winOrLoseCanvas.gameObject.SetActive(true);
            loseText.gameObject.SetActive(true);
        }
    }
}
