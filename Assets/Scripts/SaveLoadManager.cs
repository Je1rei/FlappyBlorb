using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public static class SaveLoadManager
{
    public static MusicPlayerScript musicScript;

    public static int LoadHighScore(string name)
    {
        return PlayerPrefs.GetInt(name);
    }

    public static int LoadRatioSpeed()
    {
        return PlayerPrefs.GetInt("RatioSpeed");
    }

    public static int LoadGameMode()
    {
        return PlayerPrefs.GetInt("GameMode");
    }

    public static void SaveGameMode(int gameMode)
    {
        PlayerPrefs.SetInt("GameMode", gameMode);
        PlayerPrefs.Save();

        Debug.Log($"Сохранение GameMode - {gameMode}");
    }

    public static void SaveHighScore(int highScore, string name)
    {
        PlayerPrefs.SetInt(name, highScore);
        PlayerPrefs.Save();

        Debug.Log($"Сохранение {name}");
    }

    public static void SaveRatioSpeedGame(int ratioSpeed)
    {
        PlayerPrefs.SetInt("RatioSpeed", ratioSpeed);
        PlayerPrefs.Save();

        Debug.Log("Сохранение RatioSpeed");
    }

    public static void DeleteHighScore(string name)
    {
        if (PlayerPrefs.HasKey(name))
        {
            PlayerPrefs.DeleteKey(name);
            PlayerPrefs.Save();

            Debug.Log($"Удален ключ {name}");
        }
    }

    public static void DeleteSpeedGame()
    {
        if (PlayerPrefs.HasKey("RatioSpeed"))
        {
            PlayerPrefs.DeleteKey("RatioSpeed");
            PlayerPrefs.Save();

            Debug.Log("Удален ключ RatioSpeed");
        }
    }

    public static void DeleteGameMode()
    {
        if (PlayerPrefs.HasKey("GameMode"))
        {
            PlayerPrefs.DeleteKey("GameMode");
            PlayerPrefs.Save();

            Debug.Log("Удален ключ GameMode");
        }
    }
}
