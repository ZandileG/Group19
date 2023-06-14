using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMenu : MonoBehaviour
{
  //This activates the button's functionality
    public void MainMenu()
    {
      //When the player presses the "Main Menu" button,they will be able to go back to the main menu
        SceneManager.LoadScene("Menu");
    }
}
