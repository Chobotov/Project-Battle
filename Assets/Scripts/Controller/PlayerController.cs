using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float leftHotline, rightHotline;
    
    private const float VERTICAL_HOTLINE = -22f;
    public float speed;
    private float targetPos;
    private Vector2 startPos;
    private Camera cam;
    

    void Start()
    {
        cam = GetComponent<Camera>();
        targetPos = transform.position.x;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float y = cam.ScreenToWorldPoint(Input.mousePosition).y;
            Debug.Log(y);
            if (y > VERTICAL_HOTLINE)
            {
                float position = cam.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
                targetPos = Mathf.Clamp(transform.position.x - position, leftHotline, rightHotline);
            }
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPos, speed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}
