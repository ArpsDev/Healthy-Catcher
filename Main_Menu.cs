using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene("Rules");
    }

    public void controls()
    {
        SceneManager.LoadScene("Controls");
    }
    
    public void quitgame()
    {
        Application.Quit();
    }
}

