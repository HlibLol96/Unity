using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    public void OpenSettings()
    {
       
    }

    public void Play()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void Exit()
    {
        Application.Quit();
    }
  
}