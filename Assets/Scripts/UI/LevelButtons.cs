using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SpeedLevel
{
    Start,
    Medium,
    Max
}
public class LevelButtons : MonoBehaviour
{
    public SpeedLevel levelSpeed = SpeedLevel.Start;
    public Button Pause;
    public Button Speed;
    public Button Fireball;
    public Button Mana;
    public Button FirstUnit, SecondUnit, ThirdUnit;

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

    public void NextSpeed()
    {
        switch (levelSpeed)
        {
            case SpeedLevel.Start:
                levelSpeed = SpeedLevel.Medium;
                Time.timeScale = 1.5f;
                //Debug.Log(Time.timeScale);
                break;
            case SpeedLevel.Medium:
                levelSpeed = SpeedLevel.Max;
                Time.timeScale = 2f;
                //Debug.Log(Time.timeScale);
                break;
            case SpeedLevel.Max:
                levelSpeed = SpeedLevel.Start;
                Time.timeScale = 0.5f;
                //Debug.Log(Time.timeScale);
                break;
            default:
                levelSpeed = SpeedLevel.Start;
                Time.timeScale = 1f;
                //Debug.Log(Time.timeScale);
                break;
        }
    }
}
