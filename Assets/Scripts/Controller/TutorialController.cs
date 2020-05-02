using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite[] sprites = new Sprite[6];
    [SerializeField]
    private Button nextButton,
                   readyButton;
    private int index = 0;

    private void Start()
    {
        index = 0;
        image.sprite = sprites[index];
    }

    public void NextTutorial()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.buttonClick);
        switch (index)
        {
            case 0:
                index = 1;
                image.sprite = sprites[index];
                break;
            case 1:
                index = 2;
                image.sprite = sprites[index];
                break;
            case 2:
                index = 3;
                image.sprite = sprites[index];
                break;
            case 3:
                index = 4;
                image.sprite = sprites[index];
                break;
            case 4:
                index = 5;
                image.sprite = sprites[index];
                nextButton.gameObject.SetActive(false);
                readyButton.gameObject.SetActive(true);
                break;
        }
    }

    public void ReadyToGame()
    {
        AudioManager.Instance.AudioSource.PlayOneShot(AudioManager.Instance.buttonClick);
        SaveLoadManager.Instance.playerData.SetCoinsAndEnergy(300,10);
        SaveLoadManager.Instance.playerData.isFirstLaunch = false;
        gameObject.SetActive(false);
    }
}
