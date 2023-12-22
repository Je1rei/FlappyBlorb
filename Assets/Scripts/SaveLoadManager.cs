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

        Debug.Log("���������� HighScore");
    }

    public static void SaveRatioSpeedGame(int ratioSpeed)
    {
        PlayerPrefs.SetInt("RatioSpeed", ratioSpeed);
        PlayerPrefs.Save();

        Debug.Log("���������� RatioSpeed");
    }

    public static void DeleteSaves()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.DeleteKey("HighScore");
            PlayerPrefs.Save();

            Debug.Log("������ ���� HighScore");
        }

        if (PlayerPrefs.HasKey("RatioSpeed"))
        {
            PlayerPrefs.DeleteKey("RatioSpeed");
            PlayerPrefs.Save();

            Debug.Log("������ ���� RatioSpeed");
        }
    }
}
