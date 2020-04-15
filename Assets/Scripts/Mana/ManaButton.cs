using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaButton : MonoBehaviour
{
    [SerializeField] private Text manaText;
    void Update()
    {
        //if (!GamePlay.Instance.mana.MANA_isFull)
        //{
        //    GamePlay.Instance.mana.MANA += 1;
        //    manaText.text = GamePlay.Instance.mana.MANA.ToString();
        //}
    }
}
