using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FoolsLandingLose : MonoBehaviour
{
    /* public GameObject foolsLandingTile; // assign the Fools' Landing tile in the Inspector
    public string loseSceneName; // assign the name of the Lose scene in the Inspector

    void Update()
    {
        if (!foolsLandingTile.activeInHierarchy) // check if the Fools' Landing tile is inactive
        {
            // end the game
            SceneManager.LoadScene(loseSceneName); // load the Lose scene
        }
    }*/
    public GameObject foolsLandingTile; // assign the Fools' Landing tile in the Inspector
    public GameObject winOrLoseCanvas; // assign the WinOrLoseCanvas in the Inspector

void Start()
    {
        foolsLandingTile = GameObject.Find("Flooded-islandTile_Fool'sLanding"); // find the sunk Fools' Landing tile by its name
    }
     void Update()
    {
        if (!foolsLandingTile.activeInHierarchy) // check if the Fools' Landing tile is inactive
        {
            // end the game
            winOrLoseCanvas.SetActive(true); // activate the WinOrLoseCanvas
        }
    }
}
