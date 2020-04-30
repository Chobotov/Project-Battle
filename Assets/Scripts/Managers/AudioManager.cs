using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    AudioClip mainMenu;
    [SerializeField]
    AudioClip level;
    [SerializeField]
    AudioClip buttonClick;
    [SerializeField]
    AudioClip meteorExplosion;
    [SerializeField]
    AudioClip fireballAudio;
    [SerializeField]
    AudioClip swordsdFight;
    [SerializeField]
    AudioClip punch;
    [SerializeField]
    AudioClip death;
    [SerializeField]
    AudioClip win;
    [SerializeField]
    AudioClip lose;

    public AudioClip MainMenu
    {
        get
        {
            return mainMenu;
        }
    }

    public AudioClip Level
    {
        get
        {
            return level;
        }
    }

    public AudioClip ButtonClick
    {
        get
        {
            return buttonClick;
        }
    }

    public AudioClip MeteorExplosion
    {
        get
        {
            return meteorExplosion;
        }
    }

    public AudioClip FireballAudio
    {
        get
        {
            return fireballAudio;
        }
    }

    public AudioClip SwordsFigth
    {
        get
        {
            return swordsdFight;
        }
    }

    public AudioClip Punch
    {
        get
        {
            return punch;
        }
    }

    public AudioClip Death
    {
        get
        {
            return death;
        }
    }

    public AudioClip Win
    {
        get
        {
            return win;
        }
    }

    public AudioClip Lose
    {
        get
        {
            return lose;
        }
    }

}
