using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIMenu : MonoBehaviour
{
  //This activates the "Play"button's functionality
    public void StartScreen()
    {
      //When the player presses the "Play" button, the coundown will begin
        SceneManager.LoadScene("Inventory");
    }
}
