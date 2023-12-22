using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderScript : MonoBehaviour 
{
    public LogicScript logic;
    public GameObject settingsScreen;
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

    public void SettingsScreenSetActive()
    {
        if(settingsScreen != null)
        {
            settingsScreen.SetActive(true);
        }
    }

    public void SettingsScreenSetFalse()
    {
        if (settingsScreen != null)
        {
            settingsScreen.SetActive(false);
        }
    }
}
