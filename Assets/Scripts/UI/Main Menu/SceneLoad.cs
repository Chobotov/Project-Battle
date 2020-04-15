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
       //if(GameManager.Instance.playerData.squad.currentPlayerUnits[0] != null &&
       //    GameManager.Instance.playerData.squad.currentPlayerUnits[1] != null &&
       //    GameManager.Instance.playerData.squad.currentPlayerUnits[2] != null)
       //{
       //  SceneManager.LoadScene(sceneID);
       //}
    }
}
