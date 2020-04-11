using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int MAX_MANA;
    public int MANA;
    public int FIREBALL;
    private bool isFull
    {
        get
        {
            return MANA == MAX_MANA ? true : false;
        }
    }

    [SerializeField] private Button Mana;
    [SerializeField] private Text _manaLevel;

   
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance == this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!isFull)
        {
            MANA++;
            _manaLevel.text = MANA.ToString();
        }
    }
}
