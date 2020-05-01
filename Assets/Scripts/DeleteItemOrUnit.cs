using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Unit,
    TowerUpdate
}

public enum GameMode
{
    MainMenu,
    Level
}
public class DeleteItemOrUnit : MonoBehaviour
{
    public int id;
    public Type type;
    private void OnMouseDown()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.ButtonClick, 0.3f);
        switch (type)
        {
            case Type.Unit:
                if(SaveLoadManager.Instance.playerData.isCurrentUnit.Length > 0)
                {
                    int index = SaveLoadManager.Instance.playerData.isCurrentUnit[id];
                    GameManager.Instance.allUnits[index].GetComponent<UnitData>().unitProperties.isCurrentUnit = false;
                    SaveLoadManager.Instance.playerData.isCurrentUnit[id] = int.MinValue;
                    SaveLoadManager.Instance.playerData.currentUnits[id] = null;
                    GetComponent<SpriteRenderer>().sprite = null;
                }
                break;
            case Type.TowerUpdate:
                if(SaveLoadManager.Instance.playerData.currentTowerUpdate != -1 && GameManager.Instance.gameMode == GameMode.MainMenu)
                {
                    int index = SaveLoadManager.Instance.playerData.currentTowerUpdate;
                    GameManager.Instance.towerUpdates[index].GetComponent<UnitData>().unitProperties.isCurrentUnit = false;
                    SaveLoadManager.Instance.playerData.currentTowerUpdate = -1;
                    Destroy(this.gameObject);
                    GameManager.Instance.UpdateTowerUpdates();
                }
                break;
        }
    }

    private void OnDestroy()
    {
        if(type == Type.TowerUpdate)
        {
            Destroy(this.gameObject);
        }
    }
}
