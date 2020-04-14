using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public static bool music = true;
    public static bool sounds = true;

    void Start()
    {
        InitializeManager();
    }

    private void InitializeManager()
    {
        music = System.Convert.ToBoolean(PlayerPrefs.GetString("music", "true"));
        sounds = System.Convert.ToBoolean(PlayerPrefs.GetString("sounds", "true"));
    }

    public static void SaveSettings()
    {
        PlayerPrefs.SetString("music", music.ToString());
        PlayerPrefs.SetString("sound", sounds.ToString());
        PlayerPrefs.Save();
    }
}
