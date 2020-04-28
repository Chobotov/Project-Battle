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
            GameManager.Instance.UpdateDataUnits();
            GameManager.Instance.UpdateTowerUpdates();
            if(playerData.isPurchasedItem.Count == 0)
                playerData.currentTowerUpdate = -1;
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

    public bool IsCurrentTowerUpdateEmpty()
    {
        if (playerData.currentTowerUpdate == -1 )
            return true;
        else return false;
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
