using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public string menuSceneName;// assign the name of the Menu scene in the Inspector

    public void OnClick()
    {
        SceneManager.LoadScene(menuSceneName); // load the Menu scene
    }
}
