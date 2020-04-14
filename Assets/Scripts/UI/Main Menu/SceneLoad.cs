using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneLoad : MonoBehaviour
{
    [Header("Загружаемая сцена")]
    public int sceneID;

    public void Load()
    {
       // if(GameManager.Instance.playerData.squad.currentPlayerUnits.Length == 3)
       // {
            SceneManager.LoadScene(sceneID);
        //}
    }
}
