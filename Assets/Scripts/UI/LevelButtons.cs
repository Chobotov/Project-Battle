using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : ScriptableObject
{
    Button Pause;
    Button Speed;
    Button Fireball;
    Button Mana;
    Button FirstUnit, SecondUnit, ThirdUnit;

    public void Show()
    {
        Pause.gameObject.SetActive(true);
        Speed.gameObject.SetActive(false);
        Fireball.gameObject.SetActive(false);
        Mana.gameObject.SetActive(false);
        FirstUnit.gameObject.SetActive(false);
        SecondUnit.gameObject.SetActive(false);
        ThirdUnit.gameObject.SetActive(false);
    }
    
    public void Hide()
    {
        Pause.gameObject.SetActive(false);
        Speed.gameObject.SetActive(false);
        Fireball.gameObject.SetActive(false);
        Mana.gameObject.SetActive(false);
        FirstUnit.gameObject.SetActive(false);
        SecondUnit.gameObject.SetActive(false);
        ThirdUnit.gameObject.SetActive(false);
    }
}
