using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class SwipeControl : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [Header("Коллекция игровых мест")]
    [SerializeField] private List<Transform> spots = new List<Transform>();
    [Header("Скорость перемещения камеры")]
    [SerializeField] private int speed;
    [SerializeField ]private Text spotTitle;
    //ID текущего игрового места
    private int spotID = 1;
    //Проверка листа на наличие мест
    private bool isEmpty
    {
        get
        {
            return spots.Count == 0 ? true : false;
        }
    }
    //Проверка на нажатие кнопок навигации между игровыми местами
    private bool isPressed = false;

    private void Update()
    {
        if (!isEmpty && isPressed)
        {
            CameraMoveToSpot(spotID);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if(eventData.delta.x > 0)
            {
                SwipeLeft();
            }
            else
            {
                SwipeRight();
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    private void SwipeRight()
    {
        //Debug.Log("Swipe Right");
        if (spotID == 2)
        {
            spotID = 0;
        }
        else
        {
            spotID++;
        }
        isPressed = true;
    }
    private void SwipeLeft()
    {
        //Debug.Log("Swipe Left") ;
        if (spotID == 0)
        {
            spotID = 2;
        }
        else
        {
            spotID--;
        }
        isPressed = true;
    }

    //Передвижение камеры к игровому месту
    private void CameraMoveToSpot(int spotID)
    {
        Camera.main.transform.position = new Vector3(Mathf.Lerp(Camera.main.transform.position.x, spots[spotID].transform.position.x, speed * Time.deltaTime), Camera.main.transform.position.y, Camera.main.transform.position.z);
        var delta = Mathf.Abs(Camera.main.transform.position.x - spots[spotID].transform.position.x);
        if (delta < 5)
        {
            spotTitle.text = spots[spotID].name;
            spotTitle.GetComponent<Animation>().Play();
        }
        if(delta < 0.1)
        {
            isPressed = false;
        }
    }
}
