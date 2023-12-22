using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoadManager
{
    public static MusicPlayerScript musicScript;
    public static int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    public static int LoadRatioSpeed()
    {
        return PlayerPrefs.GetInt("RatioSpeed");
    }

    public static void SaveHighScore(int highScore)
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();

        Debug.Log("Сохранение HighScore");
    }

    public static void SaveRatioSpeedGame(int ratioSpeed)
    {
        PlayerPrefs.SetInt("RatioSpeed", ratioSpeed);
        PlayerPrefs.Save();

        Debug.Log("Сохранение RatioSpeed");
    }

    public static void DeleteSaves()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.DeleteKey("HighScore");
            PlayerPrefs.Save();

            Debug.Log("Удален ключ HighScore");
        }

        if (PlayerPrefs.HasKey("RatioSpeed"))
        {
            PlayerPrefs.DeleteKey("RatioSpeed");
            PlayerPrefs.Save();

            Debug.Log("Удален ключ RatioSpeed");
        }
    }
}
