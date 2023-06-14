using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIMenu : MonoBehaviour
{
    public void Play()
    {
      //When the player presses the "Play" button, the game will start
        SceneManager.LoadScene("Game");
    }
    
    public void Quit()
    {
      //When the player presses the "Quit" button, the game will end
        Application.Quit();
    }
}
