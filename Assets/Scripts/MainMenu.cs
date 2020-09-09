using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject gameOverText;



    private void Start()
    {
    }


    public void RestartLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");

    }
}
