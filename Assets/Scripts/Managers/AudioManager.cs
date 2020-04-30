using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioStatus
{
    ON,
    OFF
}
public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    public AudioClip mainMenu;
    [SerializeField]
    public AudioClip level;
    [SerializeField]
    public AudioClip buttonClick;
    [SerializeField]
    public AudioClip buyButtonClick;
    [SerializeField]
    public AudioClip meteorExplosion;
    [SerializeField]
    public AudioClip[] fireballAudio = new AudioClip[3];
    [SerializeField]
    public AudioClip swordsdFight;
    [SerializeField]
    public AudioClip punch;
    [SerializeField]
    public AudioClip[] death = new AudioClip[3];
    [SerializeField]
    public AudioClip win;
    [SerializeField]
    public AudioClip lose;
    AudioSource audioSource;

    public AudioStatus audioStatus; 

    private void Start()
    {
        audioStatus = AudioStatus.ON;
        this.gameObject.AddComponent <AudioSource>();
        audioSource = GetComponent<AudioSource>();
    }

    public AudioSource AudioSource
    {
        get
        {
            return audioSource;
        }
        set { }
    }

    public AudioClip MainMenu
    {
        get
        {
            return mainMenu;
        }
        set { }
    }

    public AudioClip Level
    {
        get
        {
            return level;
        }
        set { }
    }

    public AudioClip ButtonClick
    {
        get
        {
            return buttonClick;
        }
        set { }
    }

    public AudioClip BuyButtonClick
    {
        get
        {
            return buyButtonClick;
        }
        set { }
    }

    public AudioClip MeteorExplosion
    {
        get
        {
            return meteorExplosion;
        }
        set { }
    }

    public AudioClip FireballAudio
    {
        get
        {
            int index = Random.Range(0, 3);
            return fireballAudio[index];
        }
        set { }
    }

    public AudioClip SwordsFigth
    {
        get
        {
            return swordsdFight;
        }
        set { }
    }

    public AudioClip Punch
    {
        get
        {
            return punch;
        }
        set { }
    }

    public AudioClip Death
    {
        get
        {
            int index = Random.Range(0, 3);
            return death[index];
        }
        set { }
    }

    public AudioClip Win
    {
        get
        {
            return win;
        }
        set { }
    }

    public AudioClip Lose
    {
        get
        {
            return lose;
        }
        set { }
    }

}
