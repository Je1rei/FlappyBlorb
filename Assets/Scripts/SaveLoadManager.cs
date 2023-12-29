using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public static class SaveLoadManager
{
    public static MusicPlayerScript musicScript;

    public static int LoadParam(string name)
    {
        return PlayerPrefs.GetInt(name);
    }
    
    public static void SaveParam(string name, int param)
    {
        PlayerPrefs.SetInt(name, param);
        PlayerPrefs.Save();

        Debug.Log($"Сохранение {name} - {param}");
    }

    public static void DeleteParam(string name)
    {
        if (PlayerPrefs.HasKey(name))
        {
            PlayerPrefs.DeleteKey(name);
            PlayerPrefs.Save();

            Debug.Log($"Удален ключ {name}");
        }
    }
}
