using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;

public class SaveSystem : Singleton<SaveSystem>
{
    public PlayerData playerData = new PlayerData();
    public UnitDataBase unitDataBase = new UnitDataBase();
    private string filepath;

    private void Start()
    {
        Debug.Log("StartSave");

        if (!PlayerPrefs.HasKey("PlayerData"))
        {
            return;
        }
        else
        {
            playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("PlayerData"));
        }

        if (!PlayerPrefs.HasKey("UnitDataBase"))
        {
            return;
        }
        else
        {
            unitDataBase = JsonUtility.FromJson<UnitDataBase>(PlayerPrefs.GetString("UnitDataBase"));
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(playerData));
        PlayerPrefs.SetString("UnitDataBase", JsonUtility.ToJson(unitDataBase));
    }
}
