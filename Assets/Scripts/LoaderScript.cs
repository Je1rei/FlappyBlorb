using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderScript : MonoBehaviour 
{
    public LogicScript logic;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        Debug.Log("PlayScene Click)");
        SceneManager.LoadScene("PlayScene");
    }

    public void RestartGame()
    {
        Debug.Log("PlayScene Click)");
        SceneManager.LoadScene("PlayScene");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("MainScene loaded)");
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
