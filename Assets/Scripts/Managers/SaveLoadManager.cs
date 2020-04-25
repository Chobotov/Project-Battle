using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    public PlayerData playerData = new PlayerData();
    private string PlayerFilepath;

    private void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        PlayerFilepath = Path.Combine(Application.persistentDataPath, "SavePlayerData.json");
#else
        PlayerFilepath = Path.Combine(Application.dataPath, "SavePlayerData.json");
#endif
        if (File.Exists(PlayerFilepath))
        {
            playerData = JsonUtility.FromJson<PlayerData>(File.ReadAllText(PlayerFilepath));
            Debug.Log("Save loaded!");
        }
    }

    public void Save()
    {
        File.WriteAllText(PlayerFilepath, JsonUtility.ToJson(playerData));
    }

    public bool IsCurrentSquadEmpty()
    {
        bool isEmpty = false;
        for (var i = 0; i < playerData.currentUnits.Length; i++)
        {
            if (playerData.currentUnits[i] == null)
            {
                isEmpty = true;
                break;
            }
        }
        return isEmpty;
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
