using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;

public class SaveSystem : Singleton<SaveSystem>
{
    public PlayerData playerData = new PlayerData();
    private string filepath;

    private void Start()
    {
        Debug.Log("StartSave");

        if (!PlayerPrefs.HasKey("Save"))
        {

        }
        else
        {
            playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("Save"));
        }

//#if UNITY_ANDROID && !UNITY_EDITOR
//        filepath = Path.Combine(Application.persistentDataPath, "Save.json");
//#else
//        filepath = Path.Combine(Application.dataPath, "Save.json");
//#endif
//        if (File.Exists(filepath))
//        {
//            playerData = JsonUtility.FromJson<PlayerData>(File.ReadAllText(filepath));
//            Debug.Log("Save is Done!");
//        }
        //else
        //{

        //}
    }

    public void SetData(int coins,int energy)
    {
        playerData.coins =  coins;
        playerData.energy = energy;
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            File.WriteAllText(filepath, JsonUtility.ToJson(playerData));
        }
    }
#endif

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Save",JsonUtility.ToJson(playerData));
        //File.WriteAllText(filepath, JsonUtility.ToJson(playerData));
    }
}
