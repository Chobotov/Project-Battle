using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseUnits : MonoBehaviour
{
    public List<Button> units = new List<Button>();
    private int id = 0;
    public void FirstButton()
    {
        id = 0;
        go(id);
        Debug.Log(GameManager.Instance.playerData.squad.currentPlayerUnits[0]);
    }


    public void SecondButton()
    {
        id = 1;
        go(id);
        Debug.Log(GameManager.Instance.playerData.squad.currentPlayerUnits[1]);
    }


    public void ThirdButton()
    {
        id = 2;
        go(id);
        Debug.Log(GameManager.Instance.playerData.squad.currentPlayerUnits[2]);
    }

    private void go(int id)
    {
        for (var i = 0; i < Main.MAX_UNITS_IN_SQUAD; i++)
        {
            if (GameManager.Instance.playerData.squad.currentPlayerUnits[i] == null)
            {
                GameManager.Instance.playerData.squad.currentPlayerUnits[i] = GameManager.Instance.playerData.squad.allUnits[id];
                break;
            }
        }
        Main.main.SetSquad();
    }
}
