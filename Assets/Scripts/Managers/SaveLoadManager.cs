using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    private float currenttimeScale = 1f;
    private const int MaxEnergy = 10;
    private const int MinutesForOneEnergy = 6;

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
            CheckTime();
            Debug.Log("Save loaded!");
        }
    }

    public void Save()
    {
        File.WriteAllText(PlayerFilepath, JsonUtility.ToJson(playerData));
    }

    private void CheckTime()
    {
        TimeSpan ts;
        if (PlayerPrefs.HasKey("LastSession") && playerData.energy < MaxEnergy)
        {
            int energy = 0;
            ts = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            if (ts.Hours >= 1)
            {
                energy = MaxEnergy;
            }
            else
            {
                energy = playerData.energy + (ts.Minutes / MinutesForOneEnergy);
            }
            playerData.SetCoinsAndEnergy(playerData.coins, energy);
            Debug.Log(playerData.energy);
            print(string.Format("Вас не было: {0} дней, {1} часов, {2} минут, {3} секунд", ts.Days, ts.Hours, ts.Minutes, ts.Seconds));
        }
        PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    }

    public bool IsCurrentSquadHasEmptySlot()
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

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Time.timeScale = currenttimeScale;
            currenttimeScale = Time.timeScale;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Save();
            currenttimeScale = Time.timeScale;
            Time.timeScale = 0f;
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
