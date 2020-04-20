using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int id;
    public Image img;

    public void OnCLICK()
    {
        Debug.Log(id);
    }
}
