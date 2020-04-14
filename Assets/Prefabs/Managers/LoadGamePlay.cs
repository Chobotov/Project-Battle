using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGamePlay : MonoBehaviour
{
    public GameObject game_play;

    private void Awake()
    {
        if (GamePlay.Instance == null)
        {
            Instantiate(game_play);
        }
    }
}
